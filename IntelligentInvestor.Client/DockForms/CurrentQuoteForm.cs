using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class CurrentQuoteForm : SingleToolDockForm
{
    private readonly IQuoteSpider quoteSpider;
    private readonly IServiceProvider serviceProvider;
    private readonly IStockRepository stockRepository;
    private readonly IQuoteRepository quoteRepository;
    private readonly IRepositoryBase<TradeStrand> tradeStrandRepository;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;

    public CurrentQuoteForm(
        ILogger<CurrentQuoteForm> logger,
        IServiceScopeFactory serviceScopeFactory,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuoteRepository quoteRepository,
        IRepositoryBase<TradeStrand> tradeStrandRepository,
        IQuoteSpider quoteSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);

        this.Icon = IntelligentInvestorResource.CurrentQuoteIcon;
        this.HideOnClose = true;
        this.CloseButton = false;
        this.CloseButtonVisible = false;

        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockEventHandler = stockEventHandler;
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
        this.tradeStrandRepository = tradeStrandRepository;
        this.quoteSpider = quoteSpider;

        this.stockEventHandler.EventRaised += StockEventHandler_EventRaised;
    }

    private Stock? currentStock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock? CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            this.currentStock = value;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            this.MainStockQuoteControl.Stock = value;
            this.MainFiveGearControl.Stock = value;

            if (value == null)
            {
                this.Invoke(new Action(() =>
                {
                    this.CurrentQuoteToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.CurrentQuoteToolStrip.Enabled = true;
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

    private Quote? currentQuote;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quote? CurrentQuote
    {
        get => this.currentQuote;
        protected set
        {
            this.currentQuote = value;
            this.MainStockQuoteControl.AttachEntity = value;
        }
    }

    private TradeStrand? currentTradeStrand;

    // TODO: Get and display Trade Strand info;
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TradeStrand? CurrentTradeStrand
    {
        get => this.currentTradeStrand;
        protected set
        {
            this.currentTradeStrand = value;
            this.MainFiveGearControl.AttachEntity = value;
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

    private void CurrentQuoteForm_Load(object sender, System.EventArgs e)
    {
        if (this.DesignMode) return;
        this.AutoRefresh = false;
    }

    public async Task RefreshQuote()
    {
        if (this.currentStock is null) return;

        try
        {
            this.logger.LogDebug($"Refresh quote of {this.currentStock?.GetFullCode()} ...");
            var (quote, tradeStrand) = await this.quoteSpider.GetQuoteAsync(this.currentStock!.StockMarket, this.currentStock!.StockCode);
            this.CurrentQuote = quote;
            this.CurrentTradeStrand = tradeStrand;

            if (quote != null) await this.quoteRepository.AddAsync(quote);
            if (tradeStrand != null) await this.tradeStrandRepository.AddAsync(tradeStrand);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"{nameof(CurrentQuoteForm)} failed to refresh quote.");
        }
    }

    private void AutoRefreshToolButton_CheckedChanged(object sender, EventArgs e)
    {
        this.AutoRefresh = this.AutoRefreshToolButton.Checked;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshQuote();
    }

    private void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
        _ = this.RefreshQuote();
    }

    private void QuoteRepositoryToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        var form = this.serviceProvider.GetRequiredService<QuoteRepositoryDocumentForm>();
        if (form == null) return;

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    private void ChartToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        var form = this.serviceProvider.GetRequiredService<ChartDocumentForm>();
        if (form == null) return;

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    private void RecentQuoteToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        var form = this.serviceProvider.GetRequiredService<RecentQuoteDocumentForm>();
        if (form == null) return;

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.CurrentQuoteToolStrip);

        this.MainStockQuoteControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainStockQuoteControl.ValueForecolor = this.themeHandler.GetContentForecolor();

        this.MainFiveGearControl.LabelForecolor = this.MainStockQuoteControl.LabelForecolor;
        this.MainFiveGearControl.ValueForecolor = this.MainStockQuoteControl.ValueForecolor;
    }

    private void CurrentQuoteForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.AutoRefreshTimer.Stop();
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
