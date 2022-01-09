using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class MarketQuotaForm : SingleToolDockForm
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string SourceName { get; set; } = typeof(MarketQuotaForm).Name;

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

            if (value == null)
            {
                this.logger.LogDebug($"{nameof(MarketQuotaForm)} selected empty stock, stop to refresh quota.");
                this.Invoke(new Action(() =>
                {
                    this.MarketQuotaToolStrip.Enabled = false;
                    this.AutoRefresh = false;
                }));
            }
            else
            {
                this.logger.LogDebug($"{nameof(MarketQuotaForm)} selected stock {value.GetFullCode()}, start to refresh quota.");
                this.Invoke(new Action(() =>
                {
                    this.AutoRefresh = true;
                    this.MarketQuotaToolStrip.Enabled = true;
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
            this.MainMarketQuotaControl.AttachEntity = value;
        }
    }

    private bool isPropertySetting = false;
    private readonly ILogger<MarketQuotaForm> logger;
    private readonly IUIThemeHandler themeHandler;
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IRepositoryBase<Quota> quotaRepository;
    private readonly IStockSpider stockSpider;

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

                // Timer 重启后会自动重置等待时间，以重新等待
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

    public MarketQuotaForm(
        ILogger<MarketQuotaForm> logger,
        IUIThemeHandler themeHandler,
        IRepositoryBase<Stock> stockRepository,
        IRepositoryBase<Quota> quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(this.themeHandler);
        this.Icon = IntelligentInvestorResource.MarketQuotaIcon;
        this.logger = logger;
        this.themeHandler = themeHandler;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;
    }

    private void MarketQuotaForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        this.AutoRefresh = false;
    }

    public void MQSubscriberReceive(string source, string topic, string message)
    {
        /*
        this.CurrentStock = stock;
        this.CurrentQuota = stock == null ? null : this.MarketQuotaService?.GetLastMarketQuota(stock.Code, stock.Market);
         */
    }

    public async Task RefreshMarketQuota()
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
        //this.Subscriber?.Dispose();
    }
}
