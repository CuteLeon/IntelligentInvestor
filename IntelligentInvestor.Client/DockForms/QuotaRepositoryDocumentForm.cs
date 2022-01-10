﻿using System.ComponentModel;
using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class QuotaRepositoryDocumentForm : DocumentDockForm
{
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
            this.Stock = this.stockRepository.Find(market, code) ?? new Stock(market, code);
        }
    }

    private Stock stock;
    private readonly IRepositoryBase<Stock> stockRepository;
    private readonly IRepositoryBase<Quota> quotaRepository;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Stock Stock
    {
        get => this.stock;
        set
        {
            this.stock = value;

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
            }
        }
    }

    public QuotaRepositoryDocumentForm(
        ILogger<QuotaRepositoryDocumentForm> logger,
        IUIThemeHandler themeHandler,
        IRepositoryBase<Stock> stockRepository,
        IRepositoryBase<Quota> quotaRepository)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        if (this.DesignMode)
        {
            return;
        }

        this.stockRepository = stockRepository;
        this.quotaRepository = quotaRepository;
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

        this.QuotaStartDatePicker.Value = DateTime.Now.AddDays(-7);
        this.QuotaEndDatePicker.Value = DateTime.Now;
    }

    private void QuotaRepositoryDockForm_Shown(object sender, EventArgs e)
    {
        this.QueryQuotas();
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
        this.QueryQuotas();
    }

    private async void QueryQuotas()
    {
        try
        {
            var query = this.quotaRepository.AsQueryable().Where(x => x.StockMarket == this.stock.StockMarket && x.StockCode == this.stock.StockCode);
            if (this.QuotaStartDatePicker.Checked)
                query = query.Where(x => x.QuotaTime >= this.QuotaStartDatePicker.Value.Date);
            if (this.QuotaEndDatePicker.Checked)
                query = query.Where(x => x.QuotaTime <= this.QuotaEndDatePicker.Value.Date);
            this.QuotaRepositoryBindingSource.DataSource = query.ToArray();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Failed to query quotas.");
        }
    }
}
