using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class CurrentQuotaForm : SingleToolDockForm
{
    private readonly IServiceProvider serviceProvider;
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IRepositoryBase<Quota> quotaRepository;
    private readonly IStockSpider stockSpider;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SourceName { get; set; } = typeof(CurrentQuotaForm).Name;

    private Stock currentStock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            this.currentStock = value;

            this.MainStockQuotaControl.Stock = value;
            this.MainFiveGearControl.Stock = value;

            if (value == null)
            {
                this.logger.LogDebug($"{nameof(CurrentQuotaForm)} selected empty stock, stop to refresh quota.");
                this.Invoke(new Action(() =>
                {
                    this.CurrentQuotaToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.logger.LogDebug($"{nameof(CurrentQuotaForm)} selected stock {value.GetFullCode()}, start to refresh quota.");
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.CurrentQuotaToolStrip.Enabled = true;
                }));
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
            this.MainStockQuotaControl.AttachEntity = value;
        }
    }

    private TradeStrand currentTradeStrand;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TradeStrand CurrentTradeStrand
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

    public CurrentQuotaForm(
        ILogger<CurrentQuotaForm> logger,
        IServiceScopeFactory serviceScopeFactory,
        IUIThemeHandler themeHandler,
        IRepositoryBase<Stock> stockRepository,
        IRepositoryBase<Quota> quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);

        this.Icon = IntelligentInvestorResource.CurrentQuotaIcon;
        this.HideOnClose = true;
        this.CloseButton = false;
        this.CloseButtonVisible = false;

        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;
    }

    private void CurrentQuotaForm_Load(object sender, System.EventArgs e)
    {
        if (this.DesignMode) return;
        this.AutoRefresh = false;
    }

    public void MQSubscriberReceive(string source, string topic, string message)
    {
        /*
        this.CurrentStock = stock;
        this.CurrentQuota = stock == null ? null : this.QuotaService?.GetLastQuota(stock.Code, stock.Market);
         */
    }

    public async Task RefreshQuota()
    {
        try
        {
            this.logger.LogDebug($"Refresh quota of {this.currentStock.GetFullCode()} ...");
            var (_, quota) = await this.stockSpider.GetStockQuotaAsync(this.currentStock.StockCode, this.currentStock.StockMarket);
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
        // this.Subscriber?.Dispose();
    }
}
