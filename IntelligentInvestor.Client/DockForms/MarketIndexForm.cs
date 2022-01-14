using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class MarketIndexForm : SingleToolDockForm
{
    private readonly ILogger<MarketIndexForm> logger;
    private readonly IUIThemeHandler themeHandler;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;
    private readonly IStockRepository stockRepository;
    private readonly IQuoteRepository quoteRepository;
    private readonly IQuoteSpider quoteSpider;

    public MarketIndexForm(
        ILogger<MarketIndexForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IStockRepository stockRepository,
        IQuoteRepository quoteRepository,
        IQuoteSpider quoteSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);
        this.Icon = IntelligentInvestorResource.MarketIndexIcon;
        this.logger = logger;
        this.themeHandler = themeHandler;
        this.stockEventHandler = stockEventHandler;
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
        this.quoteSpider = quoteSpider;

        this.stockEventHandler.EventRaised += StockEventHandler_EventRaised;
    }

    private Stock currentStock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            this.currentStock = value;
            this.MainMarketIndexControl.Stock = value;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            if (value == null)
            {
                this.Invoke(new Action(() =>
                {
                    this.MarketIndexToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.MarketIndexToolStrip.Enabled = true;
                }));
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

    private Quote currentQuote;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quote CurrentQuote
    {
        get => this.currentQuote;
        protected set
        {
            this.currentQuote = value;
            this.MainMarketIndexControl.AttachEntity = value;
        }
    }

    private bool isPropertySetting = false;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AutoRefresh
    {
        get => this.AutoRefreshToolButton.Checked;
        set
        {
            if (this.isPropertySetting) return;

            this.isPropertySetting = true;
            this.AutoRefreshToolButton.Checked = value;
            this.isPropertySetting = false;

            if (value)
            {
                this.logger.LogDebug($"Start to auto refresh quote ...");
                this.AutoRefreshToolButton.Image = IntelligentInvestorResource.Service;

                this.AutoRefreshTimer.Start();
            }
            else
            {
                this.logger.LogDebug($"Stop to auto refresh quote.");
                this.AutoRefreshToolButton.Image = IntelligentInvestorResource.ServiceFabric;
                this.AutoRefreshTimer.Stop();
            }
        }
    }

    private void StockEventHandler_EventRaised(object? sender, StockEvent e)
    {
        if (e.EventType != StockEventTypes.ChangeCurrent) return;
        this.CurrentStock = e.Stock;
        this.CurrentQuote = default;
    }

    private void MarketIndexForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        this.AutoRefresh = false;
    }


    public async Task RefreshMarketIndex()
    {
        try
        {
            this.logger.LogDebug($"Refresh quote of {this.currentStock.GetFullCode()} ...");
            var (quote, _) = await this.quoteSpider.GetQuoteAsync(this.currentStock.StockMarket, this.currentStock.StockCode);
            this.CurrentQuote = quote;

            if (quote != null)
            {
                await this.quoteRepository.AddAsync(quote);
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Failed to refresh quote.");
        }
    }

    private void AutoRefreshToolButton_CheckedChanged(object sender, EventArgs e)
    {
        this.AutoRefresh = this.AutoRefreshToolButton.Checked;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshMarketIndex();
    }

    private void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
        _ = this.RefreshMarketIndex();
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.MarketIndexToolStrip);
        this.MainMarketIndexControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainMarketIndexControl.ValueForecolor = this.themeHandler.GetContentForecolor();
    }

    private void MarketIndexForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        this.AutoRefreshTimer.Stop();
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
