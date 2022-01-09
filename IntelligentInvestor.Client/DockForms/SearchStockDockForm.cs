using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SearchStockDockForm : SingleToolDockForm
{
    private Stock currentStock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            this.currentStock = value;

            this.SearchToolStrip.Enabled = value != null;
            this.MainStockQuotaControl.Stock = value;
        }
    }

    private Quota currentQuota;
    private readonly IServiceProvider serviceProvider;
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IRepositoryBase<Quota> quotaRepository;
    private readonly IStockSpider stockSpider;

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

    public SearchStockDockForm(
        ILogger<SearchStockDockForm> logger,
        IUIThemeHandler themeHandler,
        IServiceScopeFactory serviceScopeFactory,
        IRepositoryBase<Stock> stockRepository,
        IRepositoryBase<Quota> quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);
        this.Icon = IntelligentInvestorResource.SearchIcon;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
        this.stockSpider = stockSpider;
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.SearchToolStrip);
        this.StockComboBox.BackColor = this.BackColor;
        this.StockComboBox.ForeColor = this.themeHandler.GetContentForecolor();

        this.MainStockQuotaControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainStockQuotaControl.ValueForecolor = this.StockComboBox.ForeColor;
    }

    private void AddSelfSelectToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        // MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectAdd, this.currentStock.GetFullCode());
    }

    private void RemoveSelfSelectToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        // MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectRemove, this.currentStock.GetFullCode());
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        _ = this.SearchStock(this.currentStock.StockCode, this.currentStock.StockMarket);
    }

    private void ChartToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        var form = this.serviceProvider.GetRequiredService<ChartDocumentForm>();
        if (form == null)
        {
            return;
        }

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    private void QuotaRepositoryToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        var form = this.serviceProvider.GetRequiredService<QuotaRepositoryDocumentForm>();
        if (form == null)
        {
            return;
        }

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    private async void SaveToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock != null)
        {
            await this.stockRepository.AddAsync(this.currentStock);
        }

        if (this.currentQuota != null)
        {
            await this.quotaRepository.AddAsync(this.currentQuota);
        }
    }

    private async void DeleteToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        var stock = this.stockRepository.Find(this.currentStock.StockCode, this.currentStock.StockMarket);
        if (stock != null)
        {
            await this.stockRepository.RemoveAsync(stock);
            // MQHelper.Publish(this.SourceName, MQTopics.TopicStockRemove, stock.GetFullCode());
        }
    }

    private void RecentToolStripButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        var form = this.serviceProvider.GetRequiredService<RecentQuotaDocumentForm>();
        if (form == null)
        {
            return;
        }

        form.Stock = this.currentStock;
        form.Show(this.DockPanel);
    }

    private void StockComboBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter ||
            this.StockComboBox.DroppedDown)
        {
            return;
        }

        string keyword = this.StockComboBox.Text.Trim();

        this.StockComboBox.Items.Clear();
        if (string.IsNullOrWhiteSpace(keyword))
        {
            this.CurrentStock = null;
            this.CurrentQuota = null;
        }
        else
        {
            _ = this.GetSearchStocks(keyword);
        }
    }

    public async Task GetSearchStocks(string keyword)
    {
        this.StockComboBox.Items.AddRange((await this.stockSpider.SearchStocksAsync(keyword)).ToArray());
        this.StockComboBox.DroppedDown = true;
    }

    private void StockComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (!(this.StockComboBox.SelectedItem is Stock stock))
        {
            this.CurrentStock = null;
            this.CurrentQuota = null;
        }
        else
        {
            _ = this.SearchStock(stock.StockCode, stock.StockMarket);
        }
    }

    public async Task SearchStock(string code, StockMarkets market)
    {
        var (stock, quota) = await this.stockSpider.GetStockQuotaAsync(market, code);

        this.CurrentStock = stock;
        this.CurrentQuota = quota;
    }
}
