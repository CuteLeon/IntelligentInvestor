using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Quotes;
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
    private readonly IQuoteRepository quoteRepository;
    private readonly IStockSpider stockSpider;

    public SearchStockDockForm(
        ILogger<SearchStockDockForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryPublisher intermediaryPublisher,
        IServiceScopeFactory serviceScopeFactory,
        IStockRepository stockRepository,
        IQuoteRepository quoteRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent(themeHandler);
        this.Icon = IntelligentInvestorResource.SearchIcon;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.intermediaryPublisher = intermediaryPublisher;
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
        this.stockSpider = stockSpider;
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

            this.SearchToolStrip.Enabled = value != null;
            this.MainStockQuoteControl.Stock = value;
            this.logger.LogDebug($"Set current stock => {value.GetFullCode()}");

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

    private Quote currentQuote;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quote CurrentQuote
    {
        get => this.currentQuote;
        protected set
        {
            this.currentQuote = value;
            this.MainStockQuoteControl.AttachEntity = value;
        }
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.themeHandler.CurrentThemeComponent.ApplyTo(this.SearchToolStrip);
        this.StockComboBox.BackColor = this.BackColor;
        this.StockComboBox.ForeColor = this.themeHandler.GetContentForecolor();

        this.MainStockQuoteControl.LabelForecolor = this.themeHandler.GetTitleForecolor();
        this.MainStockQuoteControl.ValueForecolor = this.StockComboBox.ForeColor;
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

        _ = this.QueryQuote(this.currentStock.StockCode, this.currentStock.StockMarket);
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

    private void QuoteRepositoryToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null)
        {
            return;
        }

        var form = this.serviceProvider.GetRequiredService<QuoteRepositoryDocumentForm>();
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

        var form = this.serviceProvider.GetRequiredService<RecentQuoteDocumentForm>();
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
            this.CurrentQuote = null;
        }
        else
        {
            await this.SearchStocks(keyword);
        }

        this.StockComboBox.DroppedDown = true;
    }

    public async Task SearchStocks(string keyword)
    {
        this.logger.LogDebug($"Search stocks with keyword {keyword} ...");
        this.StockComboBox.Items.AddRange((await this.stockSpider.SearchStocksAsync(keyword)).ToArray());
        this.StockComboBox.DroppedDown = true;
    }

    private void StockComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (this.StockComboBox.SelectedItem is not Stock stock)
        {
            this.CurrentStock = null;
            this.CurrentQuote = null;
        }
        else
        {
            _ = this.QueryQuote(stock.StockCode, stock.StockMarket);
        }
    }

    public async Task QueryQuote(string code, StockMarkets market)
    {
        this.logger.LogDebug($"Query quote of stock {this.currentStock.GetFullCode()} ...");
        var (quote, _) = await this.stockSpider.GetStockQuoteAsync(market, code);
        this.CurrentQuote = quote;
    }
}
