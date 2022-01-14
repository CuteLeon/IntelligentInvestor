using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class QuoteRepositoryDocumentForm : DocumentDockForm
{
    private readonly IStockRepository stockRepository;
    private readonly IQuoteRepository quoteRepository;

    public QuoteRepositoryDocumentForm(
        ILogger<QuoteRepositoryDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IStockRepository stockRepository,
        IQuoteRepository quoteRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.Icon = Icon.FromHandle(IntelligentInvestorResource.Context.GetHicon());
        this.QuoteFrequencyComboBox.Items.AddRange(Enum.GetNames(typeof(QuoteFrequencys)));
        this.QuoteFrequencyComboBox.SelectedIndex = 0;
        this.stockRepository = stockRepository;
        this.quoteRepository = quoteRepository;
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
                this.Text = "Quote Repository - [Empty]";
                this.StockInfoToolLabel.Text = "[Empty]";

                this.QuoteRepositoryToolStrip.Enabled = false;
            }
            else
            {
                this.Text = $"Quote Repository - {value.StockName}";
                this.StockInfoToolLabel.Text = value.StockName;
                this.QuoteRepositoryToolStrip.Enabled = true;

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

    private void QuoteRepositoryDockForm_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        ToolStripControlHost startDatePickerHost = new(this.QuoteStartDatePicker);
        ToolStripControlHost endDatePickerHost = new(this.QuoteEndDatePicker);
        int insertIndex = this.QuoteRepositoryToolStrip.Items.IndexOf(this.StartTimeToolLabel) + 1;
        this.QuoteRepositoryToolStrip.Items.Insert(insertIndex, startDatePickerHost);
        insertIndex = this.QuoteRepositoryToolStrip.Items.IndexOf(this.EndTimeToolLabel) + 1;
        this.QuoteRepositoryToolStrip.Items.Insert(insertIndex, endDatePickerHost);

        this.QuoteStartDatePicker.Value = DateTime.Today.AddDays(-7);
        this.QuoteEndDatePicker.Value = DateTime.Today.AddDays(1);
    }

    private void QuoteRepositoryDockForm_Shown(object sender, EventArgs e)
    {
    }

    public override void ApplyTheme()
    {
        base.ApplyTheme();

        this.QuoteRepositoryGridView.BackgroundColor = this.BackColor;
        this.QuoteRepositoryGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.ForeColor = this.themeHandler.GetContentForecolor();
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = this.themeHandler.GetContentHighLightBackcolor();
        this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = this.themeHandler.GetContentHighLightForecolor();

        this.QuoteRepositoryGridView.EnableHeadersVisualStyles = false;
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor = this.themeHandler.GetTitleBackcolor();
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = this.themeHandler.GetTitleForecolor();
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor;
        this.QuoteRepositoryGridView.ColumnHeadersDefaultCellStyle.Font = this.QuoteRepositoryGridView.RowTemplate.DefaultCellStyle.Font;
    }

    private void QueryToolButton_Click(object sender, EventArgs e)
    {
        this.LoadQuotes();
    }

    private async void LoadQuotes()
    {
        var frequency = Enum.TryParse(this.QuoteFrequencyComboBox.SelectedItem.ToString(), out QuoteFrequencys quoteFrequency) ? quoteFrequency : QuoteFrequencys.NotSpecified;
        this.logger.LogDebug($"Load quotes for stock {this.stock.GetFullCode()} at {frequency} frequency ...");
        try
        {
            this.QuoteRepositoryBindingSource.DataSource = await this.quoteRepository.GetStockQuotesAsync(
                this.stock.StockMarket,
                this.stock.StockCode,
                frequency,
                this.QuoteStartDatePicker.Checked ? this.QuoteStartDatePicker.Value.Date : null,
                this.QuoteEndDatePicker.Checked ? this.QuoteEndDatePicker.Value.Date : null);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Failed to query quotes.");
        }
    }
}
