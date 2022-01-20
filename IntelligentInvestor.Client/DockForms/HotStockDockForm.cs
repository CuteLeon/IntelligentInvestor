using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class HotStockDockForm : SingleToolDockForm
{
    private readonly StockBaseComparer<Stock> stockComparer = new();
    private readonly IIntermediaryPublisher intermediaryPublisher;
    private readonly IStockRepository stockRepository;
    private readonly IHotStockSpider hotStockSpider;

    public HotStockDockForm(
        ILogger<HotStockDockForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryPublisher intermediaryPublisher,
        IStockRepository stockRepository,
        IHotStockSpider hotStockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();
        this.Icon = Icon.FromHandle(IntelligentInvestorResource.Hot.GetHicon());
        this.intermediaryPublisher = intermediaryPublisher;
        this.stockRepository = stockRepository;
        this.hotStockSpider = hotStockSpider;
    }

    private Stock currentStock;

    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            if (this.currentStock == value) return;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            this.currentStock = value;
            this.RemoveToolButton.Enabled = value != null;
            this.intermediaryPublisher.PublishEvent(new StockEvent(value, StockEventTypes.ChangeCurrent));
        }
    }

    private void HotStockDockForm_Shown(object sender, EventArgs e)
    {
        _ = this.RefreshDataSource();
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.HotStocksGridView.BackgroundColor = this.BackColor;
        this.HotStocksGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.HotStocksGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.HotStocksGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.HotStocksGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.HotStocksGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.HotStocksGridView.EnableHeadersVisualStyles = false;
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.HotStocksGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.HotStocksGridView.ColumnHeadersDefaultCellStyle.Font = new Font(this.HotStocksGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Regular);
    }

    private void HotStockBindingSource_CurrentChanged(object sender, EventArgs e)
    {
        this.CurrentStock = this.HotStockBindingSource.Current as Stock;
    }

    private void AddToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;
        this.intermediaryPublisher.PublishEvent(new StockEvent(this.currentStock, StockEventTypes.Select));
    }

    private void RemoveToolButton_Click(object sender, EventArgs e)
    {
        if (this.currentStock == null) return;
        this.intermediaryPublisher.PublishEvent(new StockEvent(this.currentStock, StockEventTypes.Unselect));
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        _ = this.RefreshDataSource();
    }

    private async Task RefreshDataSource()
    {
        this.logger.LogDebug($"Get hot stocks ...");
        this.HotStockBindingSource.DataSource = await this.hotStockSpider.GetHotStocksAsync();
    }
}
