using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Comparers;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Intermediary.Application;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SelectedStockForm : SingleToolDockForm
{
    private readonly StockBaseComparer<Stock> stockComparer = new StockBaseComparer<Stock>();
    private readonly IServiceProvider serviceProvider;
    private readonly IIntermediaryEventHandler<StockEvent> stockEventHandler;
    private readonly IIntermediaryPublisher intermediaryPublisher;
    private readonly IStockRepository stockRepository;

    public SelectedStockForm(
        ILogger<SelectedStockForm> logger,
        IUIThemeHandler themeHandler,
        IIntermediaryEventHandler<StockEvent> stockEventHandler,
        IIntermediaryPublisher intermediaryPublisher,
        IServiceScopeFactory serviceScopeFactory,
        IStockRepository stockRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.SelectedStockIcon;

        this.TabPageContextMenuStrip = this.SelectedStockGridViewMenuStrip;
        this.SelectedStockStockGridView.ContextMenuStrip = this.SelectedStockGridViewMenuStrip;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockEventHandler = stockEventHandler;
        this.intermediaryPublisher = intermediaryPublisher;
        this.stockRepository = stockRepository;

        this.stockEventHandler.EventRaised += StockEventHandler_EventRaised;
    }

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
            this.logger.LogDebug($"Set current stock => {value.GetFullCode()}");

            if (value == null)
            {
                this.RemoveMenuItem.Enabled = false;
                this.RemoveToolButton.Enabled = false;
            }
            else
            {
                this.RemoveMenuItem.Enabled = true;
                this.RemoveToolButton.Enabled = true;

                try
                {
                    this.stockRepository.AddOrUpdateStock(value);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"Failed to add or update stock {value.GetFullCode}.");
                }
            }
            this.intermediaryPublisher.PublishEvent(new StockEvent(value, StockEventTypes.ChangeCurrent));
        }
    }

    private void SelectedStockStockForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }
    }

    private async void SelectedStockStockForm_Shown(object sender, EventArgs e)
    {
        try
        {
            this.Refresh();
            await this.RefreshDataSource();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Initialize {nameof(SelectedStockForm)} failed.");
        }
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();
        this.themeHandler.CurrentThemeComponent.ApplyTo(this.SelectedStockGridViewMenuStrip);

        this.SelectedStockStockGridView.BackgroundColor = this.BackColor;
        this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
        this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.SelectedStockStockGridView.EnableHeadersVisualStyles = false;
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.SelectedStockStockGridView.ColumnHeadersDefaultCellStyle.Font = new Font(this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Regular);

        this.SearchToolTextBox.BackColor = this.BackColor;
        this.SearchToolTextBox.ForeColor = this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.ForeColor;
    }

    private void StockEventHandler_EventRaised(object? sender, StockEvent e)
    {
        if (e.Stock is null) return;
        if (e.EventType == StockEventTypes.Select)
        {
            this.AddSelectedStockStock(e.Stock);
        }
        else if (e.EventType == StockEventTypes.Unselect)
        {
            this.RemoveSelectedStockStock(e.Stock);
        }
    }

    private void SelectedStockStockBindingSource_CurrentChanged(object sender, EventArgs e)
    {
        this.CurrentStock = this.SelectedStockStockBindingSource.Current as Stock;
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
        this.RemoveSelectedStockStock(this.currentStock);
    }

    private void RemoveMenuItem_Click(object sender, EventArgs e)
    {
        this.RemoveSelectedStockStock(this.currentStock);
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
                this.SelectedStockStockBindingSource.DataSource = await this.stockRepository.SearchStocksAsync(keyWord, true);
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
        this.logger.LogDebug("Load self selected stocks ...");
        try
        {
            this.SelectedStockStockBindingSource.DataSource = await this.stockRepository.SearchStocksAsync(null, true);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to refresh selected stocks.");
        }
    }

    private async void RemoveSelectedStockStock(Stock stock)
    {
        if (stock == null) return;
        stock.IsSelected = false;

        this.logger.LogDebug($"Unselect stock {stock.GetFullCode()} ...");
        try
        {
            await stockRepository.AddOrUpdateStockAsync(stock);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to unselect stock.");
        }

        var index = this.GetIndexInDataSource(stock);
        if (index != null)
        {
            this.SelectedStockStockBindingSource.RemoveAt(index.Value);
        }
    }

    private async void AddSelectedStockStock(Stock stock)
    {
        if (stock == null) return;
        stock.IsSelected = true;

        this.logger.LogDebug($"Select stock {stock.GetFullCode()} ...");
        try
        {
            await this.stockRepository.AddOrUpdateStockAsync(stock);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Failed to add self selected stock.");
        }

        if (!this.CheckDataSourceContains(stock))
        {
            this.SelectedStockStockBindingSource.Add(stock);
        }
    }

    private bool CheckDataSourceContains(Stock stock)
        => this.SelectedStockStockBindingSource.Cast<Stock>()?.Contains(stock, this.stockComparer) ?? false;

    private int? GetIndexInDataSource(Stock stock)
    {
        int index = 0;
        foreach (var current in this.SelectedStockStockBindingSource.Cast<Stock>())
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

    private void SelectedStockStockForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.stockEventHandler.EventRaised -= StockEventHandler_EventRaised;
    }
}
