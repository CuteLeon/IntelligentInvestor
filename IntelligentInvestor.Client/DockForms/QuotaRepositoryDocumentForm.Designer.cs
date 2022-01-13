namespace IntelligentInvestor.Client.DockForms
{
    partial class QuotaRepositoryDocumentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.QuotaRepositoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StartTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.EndTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaRepositoryGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openingPriceTodayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceYesterdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotaFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayHighPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayLowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotaTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotaRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuotaStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuotaEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuotaRepositoryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // QuotaRepositoryToolStrip
            // 
            this.QuotaRepositoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuotaFrequencyComboBox,
            this.StartTimeToolLabel,
            this.EndTimeToolLabel,
            this.toolStripSeparator2,
            this.QueryToolButton});
            this.QuotaRepositoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.QuotaRepositoryToolStrip.Name = "QuotaRepositoryToolStrip";
            this.QuotaRepositoryToolStrip.Size = new System.Drawing.Size(562, 25);
            this.QuotaRepositoryToolStrip.TabIndex = 0;
            this.QuotaRepositoryToolStrip.Text = "toolStrip1";
            // 
            // StockInfoToolLabel
            // 
            this.StockInfoToolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockInfoToolLabel.Name = "StockInfoToolLabel";
            this.StockInfoToolLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // StartTimeToolLabel
            // 
            this.StartTimeToolLabel.Name = "StartTimeToolLabel";
            this.StartTimeToolLabel.Size = new System.Drawing.Size(32, 22);
            this.StartTimeToolLabel.Text = "Start";
            // 
            // EndTimeToolLabel
            // 
            this.EndTimeToolLabel.Name = "EndTimeToolLabel";
            this.EndTimeToolLabel.Size = new System.Drawing.Size(32, 22);
            this.EndTimeToolLabel.Text = "End";
            // 
            // QuotaFrequencyComboBox
            // 
            this.QuotaFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuotaFrequencyComboBox.Name = "QuotaFrequencyComboBox";
            this.QuotaFrequencyComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // QueryToolButton
            // 
            this.QueryToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Search;
            this.QueryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QueryToolButton.Name = "QueryToolButton";
            this.QueryToolButton.Size = new System.Drawing.Size(52, 22);
            this.QueryToolButton.Text = "Query";
            this.QueryToolButton.Click += new System.EventHandler(this.QueryToolButton_Click);
            // 
            // QuotaRepositoryGridView
            // 
            this.QuotaRepositoryGridView.AllowUserToAddRows = false;
            this.QuotaRepositoryGridView.AllowUserToDeleteRows = false;
            this.QuotaRepositoryGridView.AllowUserToOrderColumns = true;
            this.QuotaRepositoryGridView.AllowUserToResizeRows = false;
            this.QuotaRepositoryGridView.AutoGenerateColumns = false;
            this.QuotaRepositoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuotaRepositoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuotaRepositoryGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.QuotaRepositoryGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuotaRepositoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuotaRepositoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.quotaTimeDataGridViewTextBoxColumn,
            this.openingPriceTodayDataGridViewTextBoxColumn,
            this.closingPriceYesterdayDataGridViewTextBoxColumn,
            this.dayHighPriceDataGridViewTextBoxColumn,
            this.dayLowPriceDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.QuotaRepositoryGridView.DataSource = this.QuotaRepositoryBindingSource;
            this.QuotaRepositoryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuotaRepositoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuotaRepositoryGridView.Location = new System.Drawing.Point(0, 25);
            this.QuotaRepositoryGridView.Name = "QuotaRepositoryGridView";
            this.QuotaRepositoryGridView.ReadOnly = true;
            this.QuotaRepositoryGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuotaRepositoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuotaRepositoryGridView.RowTemplate.Height = 23;
            this.QuotaRepositoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuotaRepositoryGridView.Size = new System.Drawing.Size(562, 377);
            this.QuotaRepositoryGridView.TabIndex = 1;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockCode);
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 51;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockMarket);
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 51;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.CurrentPrice);
            this.currentPriceDataGridViewTextBoxColumn.Frozen = true;
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // quotaTimeDataGridViewTextBoxColumn
            // 
            this.quotaTimeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.QuotaBase.QuotaTime);
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.quotaTimeDataGridViewTextBoxColumn.Frozen = true;
            this.quotaTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quotaTimeDataGridViewTextBoxColumn.HeaderText = "Quota Time";
            this.quotaTimeDataGridViewTextBoxColumn.Name = "quotaTimeDataGridViewTextBoxColumn";
            this.quotaTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quotaTimeDataGridViewTextBoxColumn.Width = 61;
            // 
            // openingPriceTodayDataGridViewTextBoxColumn
            // 
            this.openingPriceTodayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.OpenningPrice);
            this.openingPriceTodayDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openingPriceTodayDataGridViewTextBoxColumn.Name = "openingPriceTodayDataGridViewTextBoxColumn";
            this.openingPriceTodayDataGridViewTextBoxColumn.ReadOnly = true;
            this.openingPriceTodayDataGridViewTextBoxColumn.Width = 88;
            // 
            // closingPriceYesterdayDataGridViewTextBoxColumn
            // 
            this.closingPriceYesterdayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.ClosingPriceYesterday);
            this.closingPriceYesterdayDataGridViewTextBoxColumn.HeaderText = "Close Price Yst";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Name = "closingPriceYesterdayDataGridViewTextBoxColumn";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayHighPriceDataGridViewTextBoxColumn
            // 
            this.dayHighPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.HighestPrice);
            this.dayHighPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.dayHighPriceDataGridViewTextBoxColumn.Name = "dayHighPriceDataGridViewTextBoxColumn";
            this.dayHighPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayHighPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayLowPriceDataGridViewTextBoxColumn
            // 
            this.dayLowPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.LowestPrice);
            this.dayLowPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.dayLowPriceDataGridViewTextBoxColumn.Name = "dayLowPriceDataGridViewTextBoxColumn";
            this.dayLowPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayLowPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.Volume);
            this.countDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Width = 72;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.Amount);
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 72;
            // 
            // QuotaRepositoryBindingSource
            // 
            this.QuotaRepositoryBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotas.Quota);
            // 
            // QuotaStartDatePicker
            // 
            this.QuotaStartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaStartDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaStartDatePicker.Location = new System.Drawing.Point(94, 166);
            this.QuotaStartDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuotaStartDatePicker.Name = "QuotaStartDatePicker";
            this.QuotaStartDatePicker.ShowCheckBox = true;
            this.QuotaStartDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuotaStartDatePicker.TabIndex = 2;
            // 
            // QuotaEndDatePicker
            // 
            this.QuotaEndDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaEndDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaEndDatePicker.Location = new System.Drawing.Point(281, 166);
            this.QuotaEndDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuotaEndDatePicker.Name = "QuotaEndDatePicker";
            this.QuotaEndDatePicker.ShowCheckBox = true;
            this.QuotaEndDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuotaEndDatePicker.TabIndex = 3;
            // 
            // QuotaRepositoryDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 402);
            this.Controls.Add(this.QuotaEndDatePicker);
            this.Controls.Add(this.QuotaStartDatePicker);
            this.Controls.Add(this.QuotaRepositoryGridView);
            this.Controls.Add(this.QuotaRepositoryToolStrip);
            this.Name = "QuotaRepositoryDockForm";
            this.TabText = "Quota Repository";
            this.Text = "Quota Repository";
            this.Load += new System.EventHandler(this.QuotaRepositoryDockForm_Load);
            this.Shown += new System.EventHandler(this.QuotaRepositoryDockForm_Shown);
            this.QuotaRepositoryToolStrip.ResumeLayout(false);
            this.QuotaRepositoryToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaRepositoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip QuotaRepositoryToolStrip;
        private System.Windows.Forms.DataGridView QuotaRepositoryGridView;
        private System.Windows.Forms.BindingSource QuotaRepositoryBindingSource;
        private System.Windows.Forms.DateTimePicker QuotaStartDatePicker;
        private System.Windows.Forms.DateTimePicker QuotaEndDatePicker;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel StartTimeToolLabel;
        private System.Windows.Forms.ToolStripLabel EndTimeToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingPriceTodayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceYesterdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox QuotaFrequencyComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayHighPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayLowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotaTimeDataGridViewTextBoxColumn;
    }
}