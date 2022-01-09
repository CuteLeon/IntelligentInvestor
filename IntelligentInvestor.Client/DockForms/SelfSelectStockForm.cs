using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SelfSelectStockForm : SingleToolDockForm
{
    private readonly StockBaseComparer<Stock> stockComparer = new StockBaseComparer<Stock>();
    private readonly IServiceProvider serviceProvider;
    private readonly IRepositoryBase<Stock> stockRepository;
    private Stock currentStock;

    public Stock CurrentStock
    {
        get => this.currentStock;
        protected set
        {
            if (this.currentStock == value)
            {
                return;
            }

            this.currentStock = value;

            if (value == null)
            {
                this.RemoveMenuItem.Enabled = false;
                this.RemoveToolButton.Enabled = false;

                // MQHelper.Publish(this.SourceName, MQTopics.TopicStockCurrentChange, string.Empty);
            }
            else
            {
                this.RemoveMenuItem.Enabled = true;
                this.RemoveToolButton.Enabled = true;

                /*
                MQHelper.Publish(
                    this.SourceName,
                    MQTopics.TopicStockCurrentChange,
                    SerializerHelper.Serialize(ExpressionCloneHelper<Stock, Stock>.Clone(value)));
                 */
            }
        }
    }

    public SelfSelectStockForm(
        ILogger<SelfSelectStockForm> logger,
        IUIThemeHandler themeHandler,
        IServiceScopeFactory serviceScopeFactory,
        IRepositoryBase<Stock> stockRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.SelfSelectIcon;

        this.TabPageContextMenuStrip = this.SelfSelectGridViewMenuStrip;
        this.SelfSelectStockGridView.ContextMenuStrip = this.SelfSelectGridViewMenuStrip;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockRepository = stockRepository;
    }

    private void SelfSelectStockForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        /*
        this.Subscriber = MQHelper.Subscribe(
            this.SourceName,
            new[] { MQTopics.TopicStockSelfSelect, MQTopics.TopicStockRemove },
            this.MQSubscriberReceive);
        */
    }

    private void SelfSelectStockForm_Shown(object sender, EventArgs e)
    {
        this.Refresh();
        this.RefreshDataSource();
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();
        this.themeHandler.CurrentThemeComponent.ApplyTo(this.SelfSelectGridViewMenuStrip);

        this.SelfSelectStockGridView.BackgroundColor = this.BackColor;
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.SelfSelectStockGridView.EnableHeadersVisualStyles = false;
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.Font = new Font(this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Regular);

        this.SearchToolTextBox.BackColor = this.BackColor;
        this.SearchToolTextBox.ForeColor = this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.ForeColor;
    }

    public void MQSubscriberReceive(string source, string topic, string message)
    {
        /*
        var (code, market, name) = message.GetMarketCode();
        if (string.IsNullOrWhiteSpace(code) ||
            market == Markets.Unknown)
        {
            LogHelper<SelfSelectStockForm>.Warn($"无法处理 [代码={code},市场={market.ToString()},名称={name}] 的股票。");
            return;
        }

        Stock stock = this.StockService.Find(code, market);
        if (stock == null)
        {
            stock = new Stock(code, market, name);
        }

        switch (topic)
        {
            case MQTopics.TopicStockSelfSelectAdd:
                {
                    this.Invoke(new Action(() =>
                    {
                        this.AddSelfSelectStock(stock);
                    }));
                    break;
                }

            case MQTopics.TopicStockRemove:
            case MQTopics.TopicStockSelfSelectRemove:
                {
                    this.Invoke(new Action(() =>
                    {
                        this.RemoveSelfSelectStock(stock);
                    }));
                    break;
                }

            default:
                break;
        }
         */
    }

    private void SelfSelectStockGridView_SelectionChanged(object sender, EventArgs e)
    {
        this.CurrentStock = this.SelfSelectStockGridView.CurrentRow?.DataBoundItem as Stock;
    }

    private void RefreshToolButton_Click(object sender, EventArgs e)
    {
        this.RefreshDataSource();
    }

    private void RefreshMenuItem_Click(object sender, EventArgs e)
    {
        this.RefreshDataSource();
    }

    private void RemoveToolButton_Click(object sender, EventArgs e)
    {
        this.RemoveSelfSelectStock(this.currentStock);
    }

    private void RemoveMenuItem_Click(object sender, EventArgs e)
    {
        this.RemoveSelfSelectStock(this.currentStock);
    }

    private void SearchToolTextBox_TextChanged(object sender, EventArgs e)
    {
        string keyWord = this.SearchToolTextBox.Text;

        if (string.IsNullOrWhiteSpace(keyWord))
        {
            this.RefreshDataSource();
        }
        else
        {
            // this.SelfSelectStockBindingSource.DataSource = this.stockRepository.QueryStock(true, keyWord);
        }
    }

    private void AddToolButton_Click(object sender, EventArgs e)
    {
        this.ShowSearchStockDockForm();
    }

    private void AddMenuItem_Click(object sender, EventArgs e)
    {
        this.ShowSearchStockDockForm();
    }

    private void RefreshDataSource()
    {
        // this.SelfSelectStockBindingSource.DataSource = this.StockService.QueryStock(true);
    }

    private void RemoveSelfSelectStock(Stock stock)
    {
        if (stock == null)
        {
            return;
        }

        // this.stockRepository.RemoveSelfSelectStock(stock.Code, stock.Market);

        var index = this.GetIndexInDataSource(stock);
        if (index != null)
        {
            this.SelfSelectStockBindingSource.RemoveAt(index.Value);
        }
    }

    private void AddSelfSelectStock(Stock stock)
    {
        if (stock == null)
        {
            return;
        }

        // this.stockRepository.AddSelfSelectStock(stock);

        if (!this.CheckDataSourceContains(stock))
        {
            this.SelfSelectStockBindingSource.Add(stock);
        }
    }

    private bool CheckDataSourceContains(Stock stock)
        => (this.SelfSelectStockBindingSource.DataSource as IEnumerable<Stock>)?
            .Contains(stock, this.stockComparer) ?? false;

    private int? GetIndexInDataSource(Stock stock)
    {
        if (!(this.SelfSelectStockBindingSource.DataSource is IEnumerable<Stock> sources))
        {
            return default;
        }

        int index = 0;
        foreach (var current in sources)
        {
            if (this.stockComparer.Equals(stock, current))
            {
                return index;
            }

            index++;
        }

        return default;
    }

    private void ShowSearchStockDockForm()
    {
        SearchStockDockForm dockForm = this.serviceProvider.GetRequiredService<SearchStockDockForm>();
        if (dockForm == null)
        {
            return;
        }

        dockForm.Show(this.DockPanel);
    }

    private void SelfSelectStockForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // this.Subscriber?.Dispose();
    }
}
