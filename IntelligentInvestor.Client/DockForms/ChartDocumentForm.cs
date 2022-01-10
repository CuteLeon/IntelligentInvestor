using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class ChartDocumentForm : DocumentDockForm
{
    private Stock stock;
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IStockSpider stockSpider;

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
            this.Stock = this.stockRepository.Find(market, code) ?? new Stock(market, code);
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock Stock
    {
        get => this.stock;
        set
        {
            this.stock = value;

            if (value == null)
            {
                this.Text = "Chart-[Empty stock]";
                this.StockInfoToolLabel.Text = "[Empty stock]";
                this.ChartRepositoryToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Chart-{value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;
                this.ChartRepositoryToolStrip.Enabled = true;
            }
        }
    }

    public ChartDocumentForm(
        ILogger<DockFormBase> logger,
        IUIThemeHandler themeHandler,
        IRepositoryBase<Stock> stockRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.ChartTypeToolComboBox.Items.AddRange(Enum.GetNames(typeof(QuotaFrequencys)));
        this.ChartTypeToolComboBox.SelectedIndex = 0;
        this.stockRepository = stockRepository;
        this.stockSpider = stockSpider;
    }

    private void ChartDocumentForm_Shown(object sender, EventArgs e)
    {
        _ = this.RefreshChart();
    }

    private async Task RefreshChart()
    {
        Image chartImage = await this.stockSpider.GetChartAsync(
            this.stock.StockMarket,
            this.stock.StockCode,
            Enum.TryParse(this.ChartTypeToolComboBox.SelectedItem.ToString(), out QuotaFrequencys quotaFrequency) ? quotaFrequency : QuotaFrequencys.Trade);

        this.ChartPictureBox.BackgroundImage = chartImage;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshChart();
    }
}
