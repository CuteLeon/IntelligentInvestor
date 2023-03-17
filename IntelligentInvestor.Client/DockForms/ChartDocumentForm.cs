using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Charts;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class ChartDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IChartSpider chartSpider;
    private readonly IQuoteSpider quoteSpider;

    public ChartDocumentForm(
        ILogger<ChartDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IChartSpider chartSpider,
        IQuoteSpider quoteSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.Icon = Icon.FromHandle(IntelligentInvestorResource.Chart.GetHicon());
        this.QuoteFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuoteFrequencys)));
        this.QuoteFrequencyComboBox.SelectedIndex = 1;
        this.stockRepository = stockRepository;
        this.chartSpider = chartSpider;
        this.quoteSpider = quoteSpider;
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

            var (market, code, _) = Stock.GetMarketCode(value);
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
                    _ = this.stockRepository.AddOrUpdateStock(value);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Failed to add or update stock {value.GetFullCode}.");
                }
            }
        }
    }

    private async void ChartDocumentForm_Shown(object sender, EventArgs e)
    {
        await this.RefreshChart();
    }

    private async Task RefreshChart()
    {
        var frequency = Enum.TryParse(this.QuoteFrequencyComboBox.SelectedItem.ToString(), out QuoteFrequencys quoteFrequency) ? quoteFrequency : QuoteFrequencys.Trading;
        this.logger.LogDebug($"Refresh chart for stock {this.stock.GetFullCode()} at {frequency} frequency ...");

        try
        {
            var chartImage = await this.chartSpider.GetChartAsync(
                this.stock.StockMarket,
                this.stock.StockCode,
                frequency);

            this.ChartPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            this.ChartPictureBox.BackgroundImage = chartImage;
        }
        catch (Exception ex)
        {
            this.ChartPictureBox.BackgroundImageLayout = ImageLayout.Center;
            this.ChartPictureBox.BackgroundImage = IntelligentInvestorResource.Canceled;
            this.logger.LogError(ex, "Failed to get chart.");
        }
    }

    private async void RefreshToolButton_Click(object sender, EventArgs e)
    {
        await this.RefreshChart();
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();
        this.QuoteFrequencyComboBox.BackColor = this.themeHandler.GetContainerBackcolor();
        this.QuoteFrequencyComboBox.ForeColor = this.themeHandler.GetContentForecolor();
    }
}
