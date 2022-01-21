namespace IntelligentInvestor.Client.DockForms
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
            this.QuoteFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.StartTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.EndTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteRepositoryGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openningPriceTodayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceYesterdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayHighPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayLowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.QuoteRepositoryToolStrip.Size = new System.Drawing.Size(656, 25);
            this.QuoteRepositoryToolStrip.TabIndex = 0;
            this.QuoteRepositoryToolStrip.Text = "toolStrip1";
            // 
            // StockInfoToolLabel
            // 
            this.StockInfoToolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StockInfoToolLabel.Name = "StockInfoToolLabel";
            this.StockInfoToolLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // QuoteFrequencyComboBox
            // 
            this.QuoteFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuoteFrequencyComboBox.Name = "QuoteFrequencyComboBox";
            this.QuoteFrequencyComboBox.Size = new System.Drawing.Size(100, 25);
            // 
            // StartTimeToolLabel
            // 
            this.StartTimeToolLabel.Name = "StartTimeToolLabel";
            this.StartTimeToolLabel.Size = new System.Drawing.Size(31, 22);
            this.StartTimeToolLabel.Text = "Start";
            // 
            // EndTimeToolLabel
            // 
            this.EndTimeToolLabel.Name = "EndTimeToolLabel";
            this.EndTimeToolLabel.Size = new System.Drawing.Size(27, 22);
            this.EndTimeToolLabel.Text = "End";
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
            this.QueryToolButton.Size = new System.Drawing.Size(59, 22);
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
            this.openningPriceTodayDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.closingPriceYesterdayDataGridViewTextBoxColumn,
            this.dayHighPriceDataGridViewTextBoxColumn,
            this.dayLowPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.QuoteRepositoryGridView.DataSource = this.QuoteRepositoryBindingSource;
            this.QuoteRepositoryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuoteRepositoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuoteRepositoryGridView.Location = new System.Drawing.Point(0, 25);
            this.QuoteRepositoryGridView.Margin = new System.Windows.Forms.Padding(4);
            this.QuoteRepositoryGridView.Name = "QuoteRepositoryGridView";
            this.QuoteRepositoryGridView.ReadOnly = true;
            this.QuoteRepositoryGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuoteRepositoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuoteRepositoryGridView.RowTemplate.Height = 23;
            this.QuoteRepositoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuoteRepositoryGridView.Size = new System.Drawing.Size(656, 477);
            this.QuoteRepositoryGridView.TabIndex = 1;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 60;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 69;
            // 
            // quoteTimeDataGridViewTextBoxColumn
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.quoteTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.quoteTimeDataGridViewTextBoxColumn.Frozen = true;
            this.quoteTimeDataGridViewTextBoxColumn.HeaderText = "Quote Time";
            this.quoteTimeDataGridViewTextBoxColumn.Name = "quoteTimeDataGridViewTextBoxColumn";
            this.quoteTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteTimeDataGridViewTextBoxColumn.Width = 94;
            // 
            // quoteFrequencyDataGridViewTextBoxColumn
            // 
            this.quoteFrequencyDataGridViewTextBoxColumn.Frozen = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.quoteFrequencyDataGridViewTextBoxColumn.Name = "quoteFrequencyDataGridViewTextBoxColumn";
            this.quoteFrequencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.Width = 87;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.Frozen = true;
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPriceDataGridViewTextBoxColumn.Width = 101;
            // 
            // openningPriceTodayDataGridViewTextBoxColumn
            // 
            this.openningPriceTodayDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openningPriceTodayDataGridViewTextBoxColumn.Name = "openningPriceTodayDataGridViewTextBoxColumn";
            this.openningPriceTodayDataGridViewTextBoxColumn.ReadOnly = true;
            this.openningPriceTodayDataGridViewTextBoxColumn.Width = 90;
            // 
            // closingPriceDataGridViewTextBoxColumn
            // 
            this.closingPriceDataGridViewTextBoxColumn.HeaderText = "Close Price";
            this.closingPriceDataGridViewTextBoxColumn.Name = "closingPriceDataGridViewTextBoxColumn";
            this.closingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // closingPriceYesterdayDataGridViewTextBoxColumn
            // 
            this.closingPriceYesterdayDataGridViewTextBoxColumn.HeaderText = "Close Price Yst";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Name = "closingPriceYesterdayDataGridViewTextBoxColumn";
            this.closingPriceYesterdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Width = 108;
            // 
            // dayHighPriceDataGridViewTextBoxColumn
            // 
            this.dayHighPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.dayHighPriceDataGridViewTextBoxColumn.Name = "dayHighPriceDataGridViewTextBoxColumn";
            this.dayHighPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayHighPriceDataGridViewTextBoxColumn.Width = 102;
            // 
            // dayLowPriceDataGridViewTextBoxColumn
            // 
            this.dayLowPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.dayLowPriceDataGridViewTextBoxColumn.Name = "dayLowPriceDataGridViewTextBoxColumn";
            this.dayLowPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayLowPriceDataGridViewTextBoxColumn.Width = 98;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 72;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 76;
            // 
            // QuoteRepositoryBindingSource
            // 
            this.QuoteRepositoryBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotes.Quote);
            // 
            // QuoteStartDatePicker
            // 
            this.QuoteStartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuoteStartDatePicker.CustomFormat = "yyyy-MM-dd";
            this.QuoteStartDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuoteStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.QuoteStartDatePicker.Location = new System.Drawing.Point(110, 208);
            this.QuoteStartDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteStartDatePicker.Name = "QuoteStartDatePicker";
            this.QuoteStartDatePicker.ShowCheckBox = true;
            this.QuoteStartDatePicker.Size = new System.Drawing.Size(140, 25);
            this.QuoteStartDatePicker.TabIndex = 2;
            // 
            // QuoteEndDatePicker
            // 
            this.QuoteEndDatePicker.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuoteEndDatePicker.CustomFormat = "yyyy-MM-dd";
            this.QuoteEndDatePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuoteEndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.QuoteEndDatePicker.Location = new System.Drawing.Point(328, 208);
            this.QuoteEndDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteEndDatePicker.Name = "QuoteEndDatePicker";
            this.QuoteEndDatePicker.ShowCheckBox = true;
            this.QuoteEndDatePicker.Size = new System.Drawing.Size(140, 25);
            this.QuoteEndDatePicker.TabIndex = 3;
            // 
            // QuoteRepositoryDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 502);
            this.Controls.Add(this.QuoteEndDatePicker);
            this.Controls.Add(this.QuoteStartDatePicker);
            this.Controls.Add(this.QuoteRepositoryGridView);
            this.Controls.Add(this.QuoteRepositoryToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuoteRepositoryDocumentForm";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn openningPriceTodayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceYesterdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox QuoteFrequencyComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayHighPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayLowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteFrequencyDataGridViewTextBoxColumn;
    }
}