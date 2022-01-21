using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class QuoteHistoryDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IQuoteRepository quoteRepository;
    private readonly IQuoteSpider quoteSpider;

    public QuoteHistoryDocumentForm(
        ILogger<QuoteHistoryDocumentForm> logger,
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

        this.Icon = Icon.FromHandle(IntelligentInvestorResource.Clock.GetHicon());
        this.QuoteFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuoteFrequencys)));
        this.QuoteFrequencyComboBox.SelectedIndex = 1;
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
        this.quoteSpider = quoteSpider;

        this.codeDataGridViewTextBoxColumn.DataPropertyName = nameof(StockBase.StockCode);
        this.marketDataGridViewTextBoxColumn.DataPropertyName = nameof(StockBase.StockMarket);
        this.quoteFrequencyDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.Frequency);
        this.quoteTimeDataGridViewTextBoxColumn.DataPropertyName = nameof(QuoteBase.QuoteTime);
        this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.CurrentPrice);
        this.openningPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.OpenningPrice);
        this.closingPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.ClosingPrice);
        this.closingPriceYesterdayDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.ClosingPriceYesterday);
        this.highestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.HighestPrice);
        this.lowestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.LowestPrice);
        this.volumeDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.Volume);
        this.amountDataGridViewTextBoxColumn.DataPropertyName = nameof(Quote.Amount);
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
                this.Text = "Quote History - [Empty]";
                this.StockInfoToolLabel.Text = "[Empty]";

                this.QuoteHistoryToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Quote History - {value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;

                this.QuoteHistoryToolStrip.Enabled = true;

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

    private void QuoteHistoryDocumentForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        ToolStripControlHost startDatePickerHost = new(this.QuoteStartDatePicker);
        ToolStripControlHost endDatePickerHost = new(this.QuoteEndDatePicker);
        int insertIndex = this.QuoteHistoryToolStrip.Items.IndexOf(this.StartTimeToolLabel) + 1;
        this.QuoteHistoryToolStrip.Items.Insert(insertIndex, startDatePickerHost);
        insertIndex = this.QuoteHistoryToolStrip.Items.IndexOf(this.EndTimeToolLabel) + 1;
        this.QuoteHistoryToolStrip.Items.Insert(insertIndex, endDatePickerHost);

        this.QuoteStartDatePicker.Value = DateTime.Today.AddDays(-7);
        this.QuoteEndDatePicker.Value = DateTime.Today.AddDays(1);
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.QuoteFrequencyComboBox.BackColor = this.themeHandler.GetContainerBackcolor();
        this.QuoteFrequencyComboBox.ForeColor = this.themeHandler.GetContentForecolor();

        this.QuoteHistoryGridView.BackgroundColor = this.BackColor;
        this.QuoteHistoryGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.QuoteHistoryGridView.EnableHeadersVisualStyles = false;
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.QuoteHistoryGridView.ColumnHeadersDefaultCellStyle.Font = this.QuoteHistoryGridView.RowTemplate.DefaultCellStyle.Font;
    }

    private void QueryToolButton_Click(object sender, EventArgs e)
    {
        _ = this.QueryQuoteHistorys();
    }

    private void ExportToolButton_Click(object sender, EventArgs e)
    {
        if (this.stock == null)
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

                    var quotes = this.QuoteHistoryBindingSource.Cast<Quote>()
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
        if (this.QuoteHistoryGridView.Rows.Count == 0) return;

        /*
        var convertor = DIContainerHelper.Resolve<INOPInputConverter>();
        var prediction = DIContainerHelper.Resolve<INOPStockPrediction>();

        var modelPath = @"D:\ML\Model.zip";
        var quotes = this.QuoteHistoryBindingSource.Cast<QuoteHistory>()

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

    public async Task QueryQuoteHistorys()
    {
        if (this.stock == null) return;
        var frequency = Enum.TryParse(this.QuoteFrequencyComboBox.SelectedItem.ToString(), out QuoteFrequencys quoteFrequency) ? quoteFrequency : QuoteFrequencys.NotSpecified;
        var fromDate = this.QuoteStartDatePicker.Checked ? (DateTime?)this.QuoteStartDatePicker.Value.Date : null;
        var toDate = this.QuoteEndDatePicker.Checked ? (DateTime?)this.QuoteEndDatePicker.Value.Date : null;
        this.logger.LogDebug($"Query quotes for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        try
        {
            var quoteHistorys = await this.quoteSpider.GetQuotesAsync(
                this.stock.StockMarket,
                this.stock.StockCode,
                frequency,
                fromDate,
                toDate);
            this.QuoteHistoryBindingSource.DataSource = quoteHistorys;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Failed to query quotes.");
        }
    }
}
