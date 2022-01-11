using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SelfSelectStockForm : SingleToolDockForm
{
    private readonly StockBaseComparer<Stock> stockComparer = new StockBaseComparer<Stock>();
    private readonly IServiceProvider serviceProvider;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;
    private readonly IIntermediaryPublisher intermediaryPublisher;
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
            }
            else
            {
                this.RemoveMenuItem.Enabled = true;
                this.RemoveToolButton.Enabled = true;
            }
            this.intermediaryPublisher.PublishEvent(new StockEvent(value, StockEventTypes.ChangeCurrent));
        }
    }

    public SelfSelectStockForm(
        ILogger<SelfSelectStockForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IIntermediaryPublisher intermediaryPublisher,
        IServiceScopeFactory serviceScopeFactory,
        IRepositoryBase<Stock> stockRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.SelfSelectIcon;

        this.TabPageContextMenuStrip = this.SelfSelectGridViewMenuStrip;
        this.SelfSelectStockGridView.ContextMenuStrip = this.SelfSelectGridViewMenuStrip;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockEventHandler = stockEventHandler;
        this.intermediaryPublisher = intermediaryPublisher;
        this.stockRepository = stockRepository;

        this.stockEventHandler.EventRaised += StockEventHandler_EventRaised;
    }

    private void SelfSelectStockForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }
    }

    private async void SelfSelectStockForm_Shown(object sender, EventArgs e)
    {
        try
        {
            this.Refresh();
            await this.RefreshDataSource();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Initialize {nameof(SelfSelectStockForm)} failed.");
        }
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();
        this.themeHandler.CurrentThemeComponent.ApplyTo(this.SelfSelectGridViewMenuStrip);

        this.SelfSelectStockGridView.BackgroundColor = this.BackColor;
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
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

    private void StockEventHandler_EventRaised(object? sender, StockEvent e)
    {
        if (e.Stock is null) return;
        if (e.EventType == StockEventTypes.Select)
        {
            this.AddSelfSelectStock(e.Stock);
        }
        else if (e.EventType == StockEventTypes.Unselect)
        {
            this.RemoveSelfSelectStock(e.Stock);
        }
    }

    private void SelfSelectStockBindingSource_CurrentChanged(object sender, EventArgs e)
    {
        this.CurrentStock = this.SelfSelectStockBindingSource.Current as Stock;
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

    private async void SearchToolTextBox_TextChanged(object sender, EventArgs e)
    {
        string keyWord = this.SearchToolTextBox.Text;

        if (string.IsNullOrWhiteSpace(keyWord))
        {
            await this.RefreshDataSource();
        }
        else
        {
            try
            {
                this.SelfSelectStockBindingSource.DataSource = await this.stockRepository.AsQueryable().Where(
                    x => x.IsSelected && (EF.Functions.Like(x.StockCode, $"%{keyWord}%") || EF.Functions.Like(x.StockName, $"%{keyWord}%"))).ToArrayAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to seach stock.");
            }
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

    private async Task RefreshDataSource()
    {
        try
        {
            this.SelfSelectStockBindingSource.DataSource = await this.stockRepository.AsQueryable().Where(x => x.IsSelected).ToListAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to refresh selected stocks.");
        }
    }

    private async void RemoveSelfSelectStock(Stock stock)
    {
        if (stock == null) return;
        stock.IsSelected = false;

        try
        {
            var existedStock = this.stockRepository.Find(stock.StockMarket, stock.StockCode);
            if (existedStock is not null)
            {
                await this.stockRepository.AddAsync(stock);
            }
            else
            {
                stock = existedStock;
                stock.IsSelected = false;
                await this.stockRepository.UpdateAsync(stock);
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to remove self selected stock.");
        }

        var index = this.GetIndexInDataSource(stock);
        if (index != null)
        {
            this.SelfSelectStockBindingSource.RemoveAt(index.Value);
        }
    }

    private async void AddSelfSelectStock(Stock stock)
    {
        if (stock == null) return;
        stock.IsSelected = true;

        try
        {
            var existedStock = this.stockRepository.Find(stock.StockMarket, stock.StockCode);
            if (existedStock is null)
            {
                await this.stockRepository.AddAsync(stock);
            }
            else
            {
                stock = existedStock;
                stock.IsSelected = true;
                await this.stockRepository.UpdateAsync(stock);
            }
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to add self selected stock.");
        }

        if (!this.CheckDataSourceContains(stock))
        {
            this.SelfSelectStockBindingSource.Add(stock);
        }
    }

    private bool CheckDataSourceContains(Stock stock)
        => this.SelfSelectStockBindingSource.Cast<Stock>()?.Contains(stock, this.stockComparer) ?? false;

    private int? GetIndexInDataSource(Stock stock)
    {
        int index = 0;
        foreach (var current in this.SelfSelectStockBindingSource.Cast<Stock>())
        {
            if (this.stockComparer.Equals(stock, current)) return index;
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
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
