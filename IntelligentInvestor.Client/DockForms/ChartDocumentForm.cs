using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class ChartDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IStockSpider stockSpider;

    public ChartDocumentForm(
        ILogger<ChartDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.QuoteFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuoteFrequencys)));
        this.QuoteFrequencyComboBox.SelectedIndex = 1;
        this.stockRepository = stockRepository;
        this.stockSpider = stockSpider;
    }

    private Stock stock;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock Stock
    {
        get => this.stock;
        set
        {
            this.stock = value;
            this.logger.LogDebug($"Set current stock => {value.GetFullCode()}");

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

    private void ChartDocumentForm_Shown(object sender, EventArgs e)
    {
        _ = this.RefreshChart();
    }

    private async Task RefreshChart()
    {
        var frequency = Enum.TryParse(this.QuoteFrequencyComboBox.SelectedItem.ToString(), out QuoteFrequencys quoteFrequency) ? quoteFrequency : QuoteFrequencys.Trade;
        this.logger.LogDebug($"Refresh chart for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        Image chartImage = await this.stockSpider.GetChartAsync(
            this.stock.StockMarket,
            this.stock.StockCode,
            frequency);

        this.ChartPictureBox.BackgroundImage = chartImage;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshChart();
    }
}
