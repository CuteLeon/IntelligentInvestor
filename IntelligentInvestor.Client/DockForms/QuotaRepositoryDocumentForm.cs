using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class QuotaRepositoryDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IQuotaRepository quotaRepository;

    public QuotaRepositoryDocumentForm(
        ILogger<QuotaRepositoryDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuotaRepository quotaRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.QuotaFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuotaFrequencys)));
        this.QuotaFrequencyComboBox.SelectedIndex = 0;
        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string PersistValue
    {
        get => this.stock?.GetFullCode();
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var (code, market, _) = Stock.GetMarketCode(value);
            this.Stock = this.stockRepository.GetStock(market, code) ?? new Stock(market, code);
        }
    }

    private Stock stock;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock Stock
    {
        get => this.stock;
        set
        {
            this.stock = value;
            this.logger.LogDebug($"Set current stock => {value?.GetFullCode()}");

            if (value == null)
            {
                this.Text = "Quota Repository - [Empty]";
                this.StockInfoToolLabel.Text = "[Empty]";

                this.QuotaRepositoryToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Quota Repository - {value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;
                this.QuotaRepositoryToolStrip.Enabled = true;

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
    }

    private void QuotaRepositoryDockForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        ToolStripControlHost startDatePickerHost = new(this.QuotaStartDatePicker);
        ToolStripControlHost endDatePickerHost = new(this.QuotaEndDatePicker);
        int insertIndex = this.QuotaRepositoryToolStrip.Items.IndexOf(this.StartTimeToolLabel) + 1;
        this.QuotaRepositoryToolStrip.Items.Insert(insertIndex, startDatePickerHost);
        insertIndex = this.QuotaRepositoryToolStrip.Items.IndexOf(this.EndTimeToolLabel) + 1;
        this.QuotaRepositoryToolStrip.Items.Insert(insertIndex, endDatePickerHost);

        this.QuotaStartDatePicker.Value = DateTime.Today.AddDays(-7);
        this.QuotaEndDatePicker.Value = DateTime.Today.AddDays(1);
    }

    private void QuotaRepositoryDockForm_Shown(object sender, EventArgs e)
    {
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.QuotaRepositoryGridView.BackgroundColor = this.BackColor;
        this.QuotaRepositoryGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.QuotaRepositoryGridView.EnableHeadersVisualStyles = false;
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.Font = this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Font;
    }

    private void QueryToolButton_Click(object sender, EventArgs e)
    {
        this.LoadQuotas();
    }

    private async void LoadQuotas()
    {
        var frequency = Enum.TryParse(this.QuotaFrequencyComboBox.SelectedItem.ToString(), out QuotaFrequencys quotaFrequency) ? quotaFrequency : QuotaFrequencys.NotSpecified;
        this.logger.LogDebug($"Load quotas for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        try
        {
            this.QuotaRepositoryBindingSource.DataSource = await this.quotaRepository.GetStockQuotasAsync(
                this.stock.StockMarket,
                this.stock.StockCode,
                frequency,
                this.QuotaStartDatePicker.Checked ? this.QuotaStartDatePicker.Value.Date : null,
                this.QuotaEndDatePicker.Checked ? this.QuotaEndDatePicker.Value.Date : null);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Failed to query quotas.");
        }
    }
}
