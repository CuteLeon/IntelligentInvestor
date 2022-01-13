using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class CurrentQuotaForm : SingleToolDockForm
{
    private readonly IStockSpider stockSpider;
    private readonly IServiceProvider serviceProvider;
    private readonly IStockRepository stockRepository;
    private readonly IQuotaRepository quotaRepository;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;

    public CurrentQuotaForm(
        ILogger<CurrentQuotaForm> logger,
        IServiceScopeFactory serviceScopeFactory,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuotaRepository quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);

        this.Icon = IntelligentInvestorResource.CurrentQuotaIcon;
        this.HideOnClose = true;
        this.CloseButton = false;
        this.CloseButtonVisible = false;

        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockEventHandler = stockEventHandler;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;

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

            this.MainStockQuotaControl.Stock = value;
            this.MainFiveGearControl.Stock = value;

            if (value == null)
            {
                this.Invoke(new Action(() =>
                {
                    this.CurrentQuotaToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.CurrentQuotaToolStrip.Enabled = true;
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

    private Quota? currentQuota;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quota? CurrentQuota
    {
        get => this.currentQuota;
        protected set
        {
            this.currentQuota = value;
            this.MainStockQuotaControl.AttachEntity = value;
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
                this.logger.LogDebug($"Start to auto refresh quota ...");
                this.AutoRefreshToolButton.Image = IntelligentInvestorResource.Service;
                this.AutoRefreshTimer.Start();
            }
            else
            {
                this.logger.LogDebug($"Stop to auto refresh quota.");
                this.AutoRefreshToolButton.Image = IntelligentInvestorResource.ServiceFabric;
                this.AutoRefreshTimer.Stop();
            }
        }
    }

    private void StockEventHandler_EventRaised(object? sender, StockEvent e)
    {
        if (e.EventType != StockEventTypes.ChangeCurrent) return;
        this.CurrentStock = e.Stock;
        this.CurrentQuota = e.Stock?.Quotas?.LastOrDefault();
    }

    private void CurrentQuotaForm_Load(object sender, System.EventArgs e)
    {
        if (this.DesignMode) return;
        this.AutoRefresh = false;
    }

    public async Task RefreshQuota()
    {
        if (this.currentStock is null) return;

        try
        {
            this.logger.LogDebug($"Refresh quota of {this.currentStock?.GetFullCode()} ...");
            var (_, quota) = await this.stockSpider.GetStockQuotaAsync(this.currentStock.StockMarket, this.currentStock.StockCode);
            this.CurrentQuota = quota;

            quota.StockMarket = this.currentStock.StockMarket;
            quota.StockCode = this.currentStock.StockCode;
            if (quota != null)
            {
                await this.quotaRepository.AddAsync(quota);
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"{nameof(CurrentQuotaForm)} failed to refresh quota.");
        }
    }

    private void AutoRefreshToolButton_CheckedChanged(object sender, EventArgs e)
    {
        this.AutoRefresh = this.AutoRefreshToolButton.Checked;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshQuota();
    }

    private void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
        _ = this.RefreshQuota();
    }

    private void QuotaRepositoryToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        var form = this.serviceProvider.GetRequiredService<QuotaRepositoryDocumentForm>();
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

    private void RecentQuotaToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        var form = this.serviceProvider.GetRequiredService<RecentQuotaDocumentForm>();
        if (form == null) return;

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.CurrentQuotaToolStrip);

        this.MainStockQuotaControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainStockQuotaControl.ValueForecolor = this.themeHandler.GetContentForecolor();

        this.MainFiveGearControl.LabelForecolor = this.MainStockQuotaControl.LabelForecolor;
        this.MainFiveGearControl.ValueForecolor = this.MainStockQuotaControl.ValueForecolor;
    }

    private void CurrentQuotaForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.AutoRefreshTimer.Stop();
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
