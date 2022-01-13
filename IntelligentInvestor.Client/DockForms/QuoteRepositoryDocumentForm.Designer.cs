﻿namespace IntelligentInvestor.Client.DockForms
{
    partial class QuoteRepositoryDocumentForm
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
            this.QuoteRepositoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StartTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.EndTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteRepositoryGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openingPriceTodayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceYesterdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayHighPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayLowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuoteStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuoteEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuoteRepositoryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteRepositoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteRepositoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // QuoteRepositoryToolStrip
            // 
            this.QuoteRepositoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuoteFrequencyComboBox,
            this.StartTimeToolLabel,
            this.EndTimeToolLabel,
            this.toolStripSeparator2,
            this.QueryToolButton});
            this.QuoteRepositoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.QuoteRepositoryToolStrip.Name = "QuoteRepositoryToolStrip";
            this.QuoteRepositoryToolStrip.Size = new System.Drawing.Size(562, 25);
            this.QuoteRepositoryToolStrip.TabIndex = 0;
            this.QuoteRepositoryToolStrip.Text = "toolStrip1";
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
            // QuoteFrequencyComboBox
            // 
            this.QuoteFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuoteFrequencyComboBox.Name = "QuoteFrequencyComboBox";
            this.QuoteFrequencyComboBox.Size = new System.Drawing.Size(121, 25);
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
            // QuoteRepositoryGridView
            // 
            this.QuoteRepositoryGridView.AllowUserToAddRows = false;
            this.QuoteRepositoryGridView.AllowUserToDeleteRows = false;
            this.QuoteRepositoryGridView.AllowUserToOrderColumns = true;
            this.QuoteRepositoryGridView.AllowUserToResizeRows = false;
            this.QuoteRepositoryGridView.AutoGenerateColumns = false;
            this.QuoteRepositoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuoteRepositoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuoteRepositoryGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.QuoteRepositoryGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuoteRepositoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuoteRepositoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.quoteTimeDataGridViewTextBoxColumn,
            this.quoteFrequencyDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.openingPriceTodayDataGridViewTextBoxColumn,
            this.closingPriceYesterdayDataGridViewTextBoxColumn,
            this.dayHighPriceDataGridViewTextBoxColumn,
            this.dayLowPriceDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.QuoteRepositoryGridView.DataSource = this.QuoteRepositoryBindingSource;
            this.QuoteRepositoryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuoteRepositoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuoteRepositoryGridView.Location = new System.Drawing.Point(0, 25);
            this.QuoteRepositoryGridView.Name = "QuoteRepositoryGridView";
            this.QuoteRepositoryGridView.ReadOnly = true;
            this.QuoteRepositoryGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuoteRepositoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuoteRepositoryGridView.RowTemplate.Height = 23;
            this.QuoteRepositoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuoteRepositoryGridView.Size = new System.Drawing.Size(562, 377);
            this.QuoteRepositoryGridView.TabIndex = 1;
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
            this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.CurrentPrice);
            this.currentPriceDataGridViewTextBoxColumn.Frozen = true;
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // quoteFrequencyDataGridViewTextBoxColumn
            // 
            this.quoteFrequencyDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.Frequency);
            this.quoteFrequencyDataGridViewTextBoxColumn.Frozen = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.quoteFrequencyDataGridViewTextBoxColumn.Name = "quoteFrequencyDataGridViewTextBoxColumn";
            this.quoteFrequencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.Width = 54;
            // 
            // quoteTimeDataGridViewTextBoxColumn
            // 
            this.quoteTimeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.QuoteBase.QuoteTime);
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.quoteTimeDataGridViewTextBoxColumn.Frozen = true;
            this.quoteTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quoteTimeDataGridViewTextBoxColumn.HeaderText = "Quote Time";
            this.quoteTimeDataGridViewTextBoxColumn.Name = "quoteTimeDataGridViewTextBoxColumn";
            this.quoteTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteTimeDataGridViewTextBoxColumn.Width = 61;
            // 
            // openingPriceTodayDataGridViewTextBoxColumn
            // 
            this.openingPriceTodayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.OpenningPrice);
            this.openingPriceTodayDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openingPriceTodayDataGridViewTextBoxColumn.Name = "openingPriceTodayDataGridViewTextBoxColumn";
            this.openingPriceTodayDataGridViewTextBoxColumn.ReadOnly = true;
            this.openingPriceTodayDataGridViewTextBoxColumn.Width = 88;
            // 
            // closingPriceYesterdayDataGridViewTextBoxColumn
            // 
            this.closingPriceYesterdayDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.ClosingPriceYesterday);
            this.closingPriceYesterdayDataGridViewTextBoxColumn.HeaderText = "Close Price Yst";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Name = "closingPriceYesterdayDataGridViewTextBoxColumn";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayHighPriceDataGridViewTextBoxColumn
            // 
            this.dayHighPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.HighestPrice);
            this.dayHighPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.dayHighPriceDataGridViewTextBoxColumn.Name = "dayHighPriceDataGridViewTextBoxColumn";
            this.dayHighPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayHighPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // dayLowPriceDataGridViewTextBoxColumn
            // 
            this.dayLowPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.LowestPrice);
            this.dayLowPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.dayLowPriceDataGridViewTextBoxColumn.Name = "dayLowPriceDataGridViewTextBoxColumn";
            this.dayLowPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayLowPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.Volume);
            this.countDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Width = 72;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.Amount);
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 72;
            // 
            // QuoteRepositoryBindingSource
            // 
            this.QuoteRepositoryBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotes.Quote);
            // 
            // QuoteStartDatePicker
            // 
            this.QuoteStartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteStartDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteStartDatePicker.Location = new System.Drawing.Point(94, 166);
            this.QuoteStartDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteStartDatePicker.Name = "QuoteStartDatePicker";
            this.QuoteStartDatePicker.ShowCheckBox = true;
            this.QuoteStartDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuoteStartDatePicker.TabIndex = 2;
            // 
            // QuoteEndDatePicker
            // 
            this.QuoteEndDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteEndDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteEndDatePicker.Location = new System.Drawing.Point(281, 166);
            this.QuoteEndDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteEndDatePicker.Name = "QuoteEndDatePicker";
            this.QuoteEndDatePicker.ShowCheckBox = true;
            this.QuoteEndDatePicker.Size = new System.Drawing.Size(173, 26);
            this.QuoteEndDatePicker.TabIndex = 3;
            // 
            // QuoteRepositoryDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 402);
            this.Controls.Add(this.QuoteEndDatePicker);
            this.Controls.Add(this.QuoteStartDatePicker);
            this.Controls.Add(this.QuoteRepositoryGridView);
            this.Controls.Add(this.QuoteRepositoryToolStrip);
            this.Name = "QuoteRepositoryDockForm";
            this.TabText = "Quote Repository";
            this.Text = "Quote Repository";
            this.Load += new System.EventHandler(this.QuoteRepositoryDockForm_Load);
            this.Shown += new System.EventHandler(this.QuoteRepositoryDockForm_Shown);
            this.QuoteRepositoryToolStrip.ResumeLayout(false);
            this.QuoteRepositoryToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteRepositoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteRepositoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip QuoteRepositoryToolStrip;
        private System.Windows.Forms.DataGridView QuoteRepositoryGridView;
        private System.Windows.Forms.BindingSource QuoteRepositoryBindingSource;
        private System.Windows.Forms.DateTimePicker QuoteStartDatePicker;
        private System.Windows.Forms.DateTimePicker QuoteEndDatePicker;
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
        private System.Windows.Forms.ToolStripComboBox QuoteFrequencyComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayHighPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayLowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteFrequencyDataGridViewTextBoxColumn;
    }
}