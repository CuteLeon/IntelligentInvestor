using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class MarketQuotaForm : SingleToolDockForm
{
    private readonly ILogger<MarketQuotaForm> logger;
    private readonly IUIThemeHandler themeHandler;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;
    private readonly IStockRepository stockRepository;
    private readonly IQuotaRepository quotaRepository;
    private readonly IStockSpider stockSpider;

    public MarketQuotaForm(
        ILogger<MarketQuotaForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IStockRepository stockRepository,
        IQuotaRepository quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);
        this.Icon = IntelligentInvestorResource.MarketQuotaIcon;
        this.logger = logger;
        this.themeHandler = themeHandler;
        this.stockEventHandler = stockEventHandler;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;

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
            this.MainMarketQuotaControl.Stock = value;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            if (value == null)
            {
                this.Invoke(new Action(() =>
                {
                    this.MarketQuotaToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.MarketQuotaToolStrip.Enabled = true;
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

    private Quota currentQuota;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quota CurrentQuota
    {
        get => this.currentQuota;
        protected set
        {
            this.currentQuota = value;
            this.MainMarketQuotaControl.AttachEntity = value;
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
        this.CurrentQuota = default;
    }

    private void MarketQuotaForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        this.AutoRefresh = false;
    }


    public async Task RefreshMarketQuota()
    {
        try
        {
            this.logger.LogDebug($"Refresh quota of {this.currentStock.GetFullCode()} ...");
            var (quota, _) = await this.stockSpider.GetStockQuotaAsync(this.currentStock.StockMarket, this.currentStock.StockCode);
            this.CurrentQuota = quota;

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
        _ = this.RefreshMarketQuota();
    }

    private void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
        _ = this.RefreshMarketQuota();
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.MarketQuotaToolStrip);
        this.MainMarketQuotaControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainMarketQuotaControl.ValueForecolor = this.themeHandler.GetContentForecolor();
    }

    private void MarketQuotaForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        this.AutoRefreshTimer.Stop();
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
