namespace IntelligentInvestor.Client.DockForms
{
    partial class QuoteHistoryDocumentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.QuoteHistoryGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openningPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceYesterdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuoteHistoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuoteFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.StartTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.EndTimeToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.QuoteEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.MLTransformButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteHistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteHistoryBindingSource)).BeginInit();
            this.QuoteHistoryToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuoteHistoryGridView
            // 
            this.QuoteHistoryGridView.AllowUserToAddRows = false;
            this.QuoteHistoryGridView.AllowUserToDeleteRows = false;
            this.QuoteHistoryGridView.AllowUserToOrderColumns = true;
            this.QuoteHistoryGridView.AllowUserToResizeRows = false;
            this.QuoteHistoryGridView.AutoGenerateColumns = false;
            this.QuoteHistoryGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuoteHistoryGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuoteHistoryGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.QuoteHistoryGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuoteHistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QuoteHistoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.quoteTimeDataGridViewTextBoxColumn,
            this.quoteFrequencyDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.openningPriceDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.closingPriceYesterdayDataGridViewTextBoxColumn,
            this.highestPriceDataGridViewTextBoxColumn,
            this.lowestPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.QuoteHistoryGridView.DataSource = this.QuoteHistoryBindingSource;
            this.QuoteHistoryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuoteHistoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.QuoteHistoryGridView.Location = new System.Drawing.Point(0, 25);
            this.QuoteHistoryGridView.Name = "QuoteHistoryGridView";
            this.QuoteHistoryGridView.ReadOnly = true;
            this.QuoteHistoryGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.QuoteHistoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.QuoteHistoryGridView.RowTemplate.Height = 23;
            this.QuoteHistoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.QuoteHistoryGridView.Size = new System.Drawing.Size(522, 324);
            this.QuoteHistoryGridView.TabIndex = 3;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 54;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 54;
            // 
            // quoteFrequencyDataGridViewTextBoxColumn
            // 
            this.quoteFrequencyDataGridViewTextBoxColumn.Frozen = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.quoteFrequencyDataGridViewTextBoxColumn.Name = "quoteFrequencyDataGridViewTextBoxColumn";
            this.quoteFrequencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteFrequencyDataGridViewTextBoxColumn.Width = 54;
            // 
            // quoteTimeDataGridViewTextBoxColumn
            // 
            this.quoteTimeDataGridViewTextBoxColumn.Frozen = true;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.quoteTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.quoteTimeDataGridViewTextBoxColumn.HeaderText = "Quote Time";
            this.quoteTimeDataGridViewTextBoxColumn.Name = "quoteTimeDataGridViewTextBoxColumn";
            this.quoteTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteTimeDataGridViewTextBoxColumn.Width = 78;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Current Price";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentPriceDataGridViewTextBoxColumn.Width = 72;
            // 
            // openningPriceDataGridViewTextBoxColumn
            // 
            this.openningPriceDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openningPriceDataGridViewTextBoxColumn.Name = "openningPriceDataGridViewTextBoxColumn";
            this.openningPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openningPriceDataGridViewTextBoxColumn.Width = 90;
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
            this.closingPriceYesterdayDataGridViewTextBoxColumn.Width = 88;
            // 
            // highestPriceDataGridViewTextBoxColumn
            // 
            this.highestPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.highestPriceDataGridViewTextBoxColumn.Name = "highestPriceDataGridViewTextBoxColumn";
            this.highestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.highestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // lowestPriceDataGridViewTextBoxColumn
            // 
            this.lowestPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.lowestPriceDataGridViewTextBoxColumn.Name = "lowestPriceDataGridViewTextBoxColumn";
            this.lowestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volumn";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 66;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 72;
            // 
            // QuoteHistoryBindingSource
            // 
            this.QuoteHistoryBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotes.Quote);
            // 
            // QuoteHistoryToolStrip
            // 
            this.QuoteHistoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuoteFrequencyComboBox,
            this.StartTimeToolLabel,
            this.EndTimeToolLabel,
            this.toolStripSeparator2,
            this.ExportToolButton,
            this.MLTransformButton,
            this.toolStripSeparator3,
            this.QueryToolButton});
            this.QuoteHistoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.QuoteHistoryToolStrip.Name = "QuoteHistoryToolStrip";
            this.QuoteHistoryToolStrip.Size = new System.Drawing.Size(522, 25);
            this.QuoteHistoryToolStrip.TabIndex = 2;
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
            // QuoteFrequencyComboBox
            // 
            this.QuoteFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuoteFrequencyComboBox.Name = "QuoteFrequencyComboBox";
            this.QuoteFrequencyComboBox.Size = new System.Drawing.Size(121, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ExportToolButton
            // 
            this.ExportToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Exchange;
            this.ExportToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportToolButton.Name = "ExportToolButton";
            this.ExportToolButton.Size = new System.Drawing.Size(52, 22);
            this.ExportToolButton.Text = "Export";
            this.ExportToolButton.Click += new System.EventHandler(this.ExportToolButton_Click);
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
            // MLTransformButton
            // 
            this.MLTransformButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Insights;
            this.MLTransformButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MLTransformButton.Name = "MLTransformButton";
            this.MLTransformButton.Size = new System.Drawing.Size(70, 22);
            this.MLTransformButton.Text = "ML Train";
            this.MLTransformButton.Click += new System.EventHandler(this.MLTransformButton_Click);
            // 
            // QuoteHistoryDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 349);
            this.Controls.Add(this.QuoteEndDatePicker);
            this.Controls.Add(this.QuoteStartDatePicker);
            this.Controls.Add(this.QuoteHistoryGridView);
            this.Controls.Add(this.QuoteHistoryToolStrip);
            this.Name = "QuoteHistoryDocumentForm";
            this.TabText = "QuoteHistoryDocumentForm";
            this.Text = "QuoteHistoryDocumentForm";
            this.Load += new System.EventHandler(this.QuoteHistoryDocumentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuoteHistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteHistoryBindingSource)).EndInit();
            this.QuoteHistoryToolStrip.ResumeLayout(false);
            this.QuoteHistoryToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView QuoteHistoryGridView;
        private System.Windows.Forms.ToolStrip QuoteHistoryToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.ToolStripComboBox QuoteFrequencyComboBox;
        private System.Windows.Forms.ToolStripLabel StartTimeToolLabel;
        private System.Windows.Forms.ToolStripLabel EndTimeToolLabel;
        private System.Windows.Forms.DateTimePicker QuoteStartDatePicker;
        private System.Windows.Forms.DateTimePicker QuoteEndDatePicker;
        private System.Windows.Forms.BindingSource QuoteHistoryBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openningPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceYesterdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteFrequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton MLTransformButton;
    }
}