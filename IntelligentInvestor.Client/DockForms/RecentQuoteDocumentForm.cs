﻿using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class RecentQuoteDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IQuoteRepository quoteRepository;
    private readonly IQuoteSpider quoteSpider;

    public RecentQuoteDocumentForm(
        ILogger<RecentQuoteDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuoteRepository quoteRepository,
        IQuoteSpider quoteSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.QuoteFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuoteFrequencys)));
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
        this.quoteSpider = quoteSpider;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string PersistValue
    {
        get => this.stock?.GetFullCode();
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var (code, market, _) = Stock.GetMarketCode(value);
            this.Stock = this.stockRepository.GetStock(market, code) ?? new Stock(market, code);
        }
    }

    private Stock stock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock Stock
    {
        get => this.stock;
        set
        {
            this.stock = value;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            if (value == null)
            {
                this.Text = "Recent Quote - [Empty]";
                this.StockInfoToolLabel.Text = "[Empty]";

                this.RecentQuoteToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Recent Quote - {value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;

                this.RecentQuoteToolStrip.Enabled = true;

                try
                {
                    this.stockRepository.AddOrUpdateStock(value);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Failed to add or update stock {value.GetFullCode}.");
                }
            }
        }
    }

    private void RecentQuoteDocumentForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        ToolStripControlHost quoteLengthNumericHost = new ToolStripControlHost(this.QuoteLengthNumeric);
        int insertIndex = this.RecentQuoteToolStrip.Items.IndexOf(this.QuoteLengthToolLabel) + 1;
        this.RecentQuoteToolStrip.Items.Insert(insertIndex, quoteLengthNumericHost);

        this.QuoteFrequencyComboBox.SelectedIndex = 0;
        this.QuoteLengthNumeric.Value = 20;
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.RecentQuoteGridView.BackgroundColor = this.BackColor;
        this.RecentQuoteGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.RecentQuoteGridView.EnableHeadersVisualStyles = false;
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.RecentQuoteGridView.ColumnHeadersDefaultCellStyle.Font = this.RecentQuoteGridView.RowTemplate.DefaultCellStyle.Font;
    }

    private void QueryToolButton_Click(object sender, EventArgs e)
    {
        _ = this.QueryRecentQuotes();
    }

    private void ExportToolButton_Click(object sender, EventArgs e)
    {
        if (this.stock == null)
        {
            return;
        }

        if (this.RecentQuoteGridView.Rows.Count == 0)
        {
            return;
        }

        using (var dialog = new SaveFileDialog()
        {
            DefaultExt = ".txt",
            FileName = $"{this.Stock.StockName}-{this.Stock.StockCode}_Quotes",
            Filter = "Text files|*.txt|All files|*.*",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            Title = "Please select export file path:",
        })
        {
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string fileName = dialog.FileName;
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    string line = "Code\tMarket\tName\tOpenPrice\tClosePrice\tHighestPrice\tLowestPrice\tVolumn\tQuoteTime\tNextOpenPrice";
                    streamWriter.WriteLine(line);

                    var quotes = this.RecentQuoteBindingSource.Cast<Quote>()
                        .OrderByDescending(quote => quote.QuoteTime)
                        .ToList();

                    var firstQuote = quotes.First();
                    line = $"{firstQuote.StockCode}\t{firstQuote.StockMarket}\t{stock.StockName}\t{firstQuote.OpenningPrice}\t{firstQuote.ClosingPrice}\t{firstQuote.HighestPrice}\t{firstQuote.LowestPrice}\t{firstQuote.Volume}\t{firstQuote.QuoteTime}\t{string.Empty}";
                    streamWriter.WriteLine(line);

                    quotes.Skip(1)
                        .Select((quote, index) =>
                        {
                            line = $"{quote.StockCode}\t{quote.StockMarket}\t{stock.StockName}\t{quote.OpenningPrice}\t{quote.ClosingPrice}\t{quote.HighestPrice}\t{quote.LowestPrice}\t{quote.Volume}\t{quote.QuoteTime}\t{quotes[index].OpenningPrice}";
                            streamWriter.WriteLine(line);
                            return line;
                        })
                        .Count();
                }
            }
        }

        MessageBox.Show(this, $"{this.Stock.StockName}-{this.Stock.StockCode} quotes exported successfully!", "Export successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void MLTransformButton_Click(object sender, EventArgs e)
    {
        if (this.stock == null) return;
        if (this.RecentQuoteGridView.Rows.Count == 0) return;

        /*
        var convertor = DIContainerHelper.Resolve<INOPInputConverter>();
        var prediction = DIContainerHelper.Resolve<INOPStockPrediction>();

        var modelPath = @"D:\ML\Model.zip";
        var quotes = this.RecentQuoteBindingSource.Cast<RecentQuote>()

        // if (!File.Exists(modelPath))
        {
            var transformer = DIContainerHelper.Resolve<INOPStockTransformer>();
            var inputs = convertor.ConvertInputs(quotes);
            transformer.InitializeEstimator();
            transformer.Fit(inputs);
            transformer.SaveModel(modelPath);
            var result = transformer.Evaluate();
            MessageBox.Show($"模型评估结果：\n\tL1={result.L1}\n\tL2={result.L2}\n\tLossFunction={result.LossFunction}\n\tRMS={result.RMS}\n\tR2={result.R2}");
        }

        var quote = quotes.First();
        var input = convertor.ConvertInput(quote);
        prediction.LoadModelToPredictionEngine(modelPath);
        var output = prediction.Predict(input);
        MessageBox.Show($"预测结果：{output.NextOpenPrice}");
         */
    }

    public async Task QueryRecentQuotes()
    {
        if (this.stock == null) return;
        var frequency = Enum.TryParse(this.QuoteFrequencyComboBox.SelectedItem.ToString(), out QuoteFrequencys quoteFrequency) ? quoteFrequency : QuoteFrequencys.NotSpecified;
        this.logger.LogDebug($"Query quotes for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        var recentQuotes = await this.quoteSpider.GetQuotesAsync(
            this.stock.StockMarket,
            this.stock.StockCode,
            frequency,
            DateTime.Now.AddMinutes(-1 * Convert.ToInt32(this.QuoteLengthNumeric.Value)),
            DateTime.Now);
        this.RecentQuoteBindingSource.DataSource = recentQuotes;
    }
}
