using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class RecentQuotaDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IQuotaRepository quotaRepository;
    private readonly IStockSpider stockSpider;

    public RecentQuotaDocumentForm(
        ILogger<RecentQuotaDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuotaRepository quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.QuotaFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuotaFrequencys)));
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;
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
                this.Text = "Recent Quota - [Empty]";
                this.StockInfoToolLabel.Text = "[Empty]";

                this.RecentQuotaToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Recent Quota - {value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;

                this.RecentQuotaToolStrip.Enabled = true;

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

    private void RecentQuotaDocumentForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        ToolStripControlHost quotaLengthNumericHost = new ToolStripControlHost(this.QuotaLengthNumeric);
        int insertIndex = this.RecentQuotaToolStrip.Items.IndexOf(this.QuotaLengthToolLabel) + 1;
        this.RecentQuotaToolStrip.Items.Insert(insertIndex, quotaLengthNumericHost);

        this.QuotaFrequencyComboBox.SelectedIndex = 0;
        this.QuotaLengthNumeric.Value = 20;
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.RecentQuotaGridView.BackgroundColor = this.BackColor;
        this.RecentQuotaGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.RecentQuotaGridView.EnableHeadersVisualStyles = false;
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.Font = this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Font;
    }

    private void QueryToolButton_Click(object sender, EventArgs e)
    {
        _ = this.QueryRecentQuotas();
    }

    private void ExportToolButton_Click(object sender, EventArgs e)
    {
        if (this.stock == null)
        {
            return;
        }

        if (this.RecentQuotaGridView.Rows.Count == 0)
        {
            return;
        }

        using (var dialog = new SaveFileDialog()
        {
            DefaultExt = ".txt",
            FileName = $"{this.Stock.StockName}-{this.Stock.StockCode}_Quotas",
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
                    string line = "Code\tMarket\tName\tOpenPrice\tClosePrice\tHighestPrice\tLowestPrice\tVolumn\tQuotaTime\tNextOpenPrice";
                    streamWriter.WriteLine(line);

                    var quotas = this.RecentQuotaBindingSource.Cast<Quota>()
                        .OrderByDescending(quota => quota.QuotaTime)
                        .ToList();

                    var firstQuota = quotas.First();
                    line = $"{firstQuota.StockCode}\t{firstQuota.StockMarket}\t{stock.StockName}\t{firstQuota.OpenningPrice}\t{firstQuota.ClosingPrice}\t{firstQuota.HighestPrice}\t{firstQuota.LowestPrice}\t{firstQuota.Volume}\t{firstQuota.QuotaTime}\t{string.Empty}";
                    streamWriter.WriteLine(line);

                    quotas.Skip(1)
                        .Select((quota, index) =>
                        {
                            line = $"{quota.StockCode}\t{quota.StockMarket}\t{stock.StockName}\t{quota.OpenningPrice}\t{quota.ClosingPrice}\t{quota.HighestPrice}\t{quota.LowestPrice}\t{quota.Volume}\t{quota.QuotaTime}\t{quotas[index].OpenningPrice}";
                            streamWriter.WriteLine(line);
                            return line;
                        })
                        .Count();
                }
            }
        }

        MessageBox.Show(this, $"{this.Stock.StockName}-{this.Stock.StockCode} quotas exported successfully!", "Export successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void MLTransformButton_Click(object sender, EventArgs e)
    {
        if (this.stock == null) return;
        if (this.RecentQuotaGridView.Rows.Count == 0) return;

        /*
        var convertor = DIContainerHelper.Resolve<INOPInputConverter>();
        var prediction = DIContainerHelper.Resolve<INOPStockPrediction>();

        var modelPath = @"D:\ML\Model.zip";
        var quotas = this.RecentQuotaBindingSource.Cast<RecentQuota>()

        // if (!File.Exists(modelPath))
        {
            var transformer = DIContainerHelper.Resolve<INOPStockTransformer>();
            var inputs = convertor.ConvertInputs(quotas);
            transformer.InitializeEstimator();
            transformer.Fit(inputs);
            transformer.SaveModel(modelPath);
            var result = transformer.Evaluate();
            MessageBox.Show($"模型评估结果：\n\tL1={result.L1}\n\tL2={result.L2}\n\tLossFunction={result.LossFunction}\n\tRMS={result.RMS}\n\tR2={result.R2}");
        }

        var quota = quotas.First();
        var input = convertor.ConvertInput(quota);
        prediction.LoadModelToPredictionEngine(modelPath);
        var output = prediction.Predict(input);
        MessageBox.Show($"预测结果：{output.NextOpenPrice}");
         */
    }

    public async Task QueryRecentQuotas()
    {
        if (this.stock == null) return;
        var frequency = Enum.TryParse(this.QuotaFrequencyComboBox.SelectedItem.ToString(), out QuotaFrequencys quotaFrequency) ? quotaFrequency : QuotaFrequencys.NotSpecified;
        this.logger.LogDebug($"Query quotas for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        var recentQuotas = await this.stockSpider.GetQuotasAsync(
            this.stock.StockMarket,
            this.stock.StockCode,
            frequency,
            DateTime.Now.AddMinutes(-1 * Convert.ToInt32(this.QuotaLengthNumeric.Value)),
            DateTime.Now);
        this.RecentQuotaBindingSource.DataSource = recentQuotas;
    }
}
