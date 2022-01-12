using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SearchStockDockForm : SingleToolDockForm
{
    private readonly IServiceProvider serviceProvider;
    private readonly IIntermediaryPublisher intermediaryPublisher;
    private readonly IStockRepository stockRepository;
    private readonly IQuotaRepository quotaRepository;
    private readonly IStockSpider stockSpider;

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

    public SearchStockDockForm(
        ILogger<SearchStockDockForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryPublisher intermediaryPublisher,
        IServiceScopeFactory serviceScopeFactory,
        IStockRepository stockRepository,
        IQuotaRepository quotaRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);
        this.Icon = IntelligentInvestorResource.SearchIcon;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.intermediaryPublisher = intermediaryPublisher;
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
        if (this.currentStock == null) return;
        this.intermediaryPublisher.PublishEvent(new StockEvent(this.currentStock, StockEventTypes.Select));
    }

    private void RemoveSelfSelectToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;
        this.intermediaryPublisher.PublishEvent(new StockEvent(this.currentStock, StockEventTypes.Unselect));
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
            try
            {
                await this.stockRepository.AddAsync(this.currentStock);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to save stock.");
            }
        }
    }

    private async void DeleteToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;

        try
        {
            var stock = this.stockRepository.GetStock(this.currentStock.StockMarket, this.currentStock.StockCode);
            if (stock != null)
            {
                await this.stockRepository.RemoveAsync(stock);
            }

            if (currentStock.IsSelected)
                await this.intermediaryPublisher.PublishEvent(new StockEvent(this.currentStock, StockEventTypes.Unselect));
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to remove stock.");
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

    private async void StockComboBox_KeyDown(object sender, KeyEventArgs e)
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
            await this.GetSearchStocks(keyword);
        }

        this.StockComboBox.DroppedDown = true;
    }

    public async Task GetSearchStocks(string keyword)
    {
        this.StockComboBox.Items.AddRange((await this.stockSpider.SearchStocksAsync(keyword)).ToArray());
        this.StockComboBox.DroppedDown = true;
    }

    private void StockComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (this.StockComboBox.SelectedItem is not Stock stock)
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
