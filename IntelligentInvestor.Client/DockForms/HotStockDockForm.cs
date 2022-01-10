using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class HotStockDockForm : SingleToolDockForm
{
    private readonly StockBaseComparer<Stock> stockComparer = new();
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IStockSpider stockSpider;

    private Stock currentStock;

    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            if (this.currentStock == value) return;

            this.currentStock = value;
            if (value == null)
            {
                this.RemoveToolButton.Enabled = false;
            }
            else
            {
                this.RemoveToolButton.Enabled = true;
            }
        }
    }

    public HotStockDockForm(
        ILogger<HotStockDockForm> logger,
        IUIThemeHandler themeHandler,
        IRepositoryBase<Stock> stockRepository,
        IStockSpider stockSpider)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();
        this.Icon = IntelligentInvestorResource.HotIcon;
        this.stockRepository = stockRepository;
        this.stockSpider = stockSpider;
    }

    private void HotStockDockForm_Shown(object sender, System.EventArgs e)
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

    private void HotStocksGridView_SelectionChanged(object sender, System.EventArgs e)
    {
        this.CurrentStock = this.HotStocksGridView.CurrentRow?.DataBoundItem as Stock;
    }

    private void AddToolButton_Click(object sender, System.EventArgs e)
    {
        if (this.currentStock == null) return;
        // MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectAdd, this.currentStock.GetFullCode());
    }

    private void RemoveToolButton_Click(object sender, System.EventArgs e)
    {
        if (this.currentStock == null) return;
        // MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectRemove, this.currentStock.GetFullCode());
    }

    private void RefreshToolButton_Click(object sender, System.EventArgs e)
    {
        _ = this.RefreshDataSource();
    }

    private async Task RefreshDataSource()
    {
        this.HotStockBindingSource.DataSource = await this.stockSpider.GetHotStocksAsync();
    }
}
