namespace IntelligentInvestor.Client.DockForms
{
    partial class RecentQuoteDocumentForm
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
            this.RecentQuoteGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openningPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quoteFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecentQuoteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecentQuoteToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuoteFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.QuoteLengthToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.MLTransformButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuoteGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuoteBindingSource)).BeginInit();
            this.RecentQuoteToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteLengthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // RecentQuoteGridView
            // 
            this.RecentQuoteGridView.AllowUserToAddRows = false;
            this.RecentQuoteGridView.AllowUserToDeleteRows = false;
            this.RecentQuoteGridView.AllowUserToOrderColumns = true;
            this.RecentQuoteGridView.AllowUserToResizeRows = false;
            this.RecentQuoteGridView.AutoGenerateColumns = false;
            this.RecentQuoteGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RecentQuoteGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecentQuoteGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RecentQuoteGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuoteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecentQuoteGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.quoteTimeDataGridViewTextBoxColumn,
            this.quoteFrequencyDataGridViewTextBoxColumn,
            this.openningPriceDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.highestPriceDataGridViewTextBoxColumn,
            this.lowestPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.RecentQuoteGridView.DataSource = this.RecentQuoteBindingSource;
            this.RecentQuoteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentQuoteGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RecentQuoteGridView.Location = new System.Drawing.Point(0, 25);
            this.RecentQuoteGridView.Name = "RecentQuoteGridView";
            this.RecentQuoteGridView.ReadOnly = true;
            this.RecentQuoteGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuoteGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RecentQuoteGridView.RowTemplate.Height = 23;
            this.RecentQuoteGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecentQuoteGridView.Size = new System.Drawing.Size(522, 324);
            this.RecentQuoteGridView.TabIndex = 3;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockCode);
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 54;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockMarket);
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 54;
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
            this.quoteTimeDataGridViewTextBoxColumn.Frozen = true;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.quoteTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.quoteTimeDataGridViewTextBoxColumn.HeaderText = "Quote Time";
            this.quoteTimeDataGridViewTextBoxColumn.Name = "quoteTimeDataGridViewTextBoxColumn";
            this.quoteTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quoteTimeDataGridViewTextBoxColumn.Width = 78;
            // 
            // openningPriceDataGridViewTextBoxColumn
            // 
            this.openningPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.OpenningPrice);
            this.openningPriceDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openningPriceDataGridViewTextBoxColumn.Name = "openningPriceDataGridViewTextBoxColumn";
            this.openningPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openningPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // closingPriceDataGridViewTextBoxColumn
            // 
            this.closingPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.ClosingPrice);
            this.closingPriceDataGridViewTextBoxColumn.HeaderText = "Close Price";
            this.closingPriceDataGridViewTextBoxColumn.Name = "closingPriceDataGridViewTextBoxColumn";
            this.closingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // highestPriceDataGridViewTextBoxColumn
            // 
            this.highestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.HighestPrice);
            this.highestPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.highestPriceDataGridViewTextBoxColumn.Name = "highestPriceDataGridViewTextBoxColumn";
            this.highestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.highestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // lowestPriceDataGridViewTextBoxColumn
            // 
            this.lowestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.LowestPrice);
            this.lowestPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.lowestPriceDataGridViewTextBoxColumn.Name = "lowestPriceDataGridViewTextBoxColumn";
            this.lowestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotes.Quote.Volume);
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volumn";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 66;
            // 
            // RecentQuoteBindingSource
            // 
            this.RecentQuoteBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotes.Quote);
            // 
            // RecentQuoteToolStrip
            // 
            this.RecentQuoteToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuoteFrequencyComboBox,
            this.QuoteLengthToolLabel,
            this.toolStripSeparator2,
            this.ExportToolButton,
            this.MLTransformButton,
            this.toolStripSeparator3,
            this.QueryToolButton});
            this.RecentQuoteToolStrip.Location = new System.Drawing.Point(0, 0);
            this.RecentQuoteToolStrip.Name = "RecentQuoteToolStrip";
            this.RecentQuoteToolStrip.Size = new System.Drawing.Size(522, 25);
            this.RecentQuoteToolStrip.TabIndex = 2;
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
            // QuoteLengthToolLabel
            // 
            this.QuoteLengthToolLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuoteLengthToolLabel.Name = "QuoteLengthToolLabel";
            this.QuoteLengthToolLabel.Size = new System.Drawing.Size(56, 22);
            this.QuoteLengthToolLabel.Text = "Count";
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
            // QuoteLengthNumeric
            // 
            this.QuoteLengthNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuoteLengthNumeric.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteLengthNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.QuoteLengthNumeric.Location = new System.Drawing.Point(224, 149);
            this.QuoteLengthNumeric.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.QuoteLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuoteLengthNumeric.Name = "QuoteLengthNumeric";
            this.QuoteLengthNumeric.Size = new System.Drawing.Size(120, 22);
            this.QuoteLengthNumeric.TabIndex = 4;
            this.QuoteLengthNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
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
            // RecentQuoteDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 349);
            this.Controls.Add(this.QuoteLengthNumeric);
            this.Controls.Add(this.RecentQuoteGridView);
            this.Controls.Add(this.RecentQuoteToolStrip);
            this.Name = "RecentQuoteDocumentForm";
            this.TabText = "RecentQuoteDocumentForm";
            this.Text = "RecentQuoteDocumentForm";
            this.Load += new System.EventHandler(this.RecentQuoteDocumentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuoteGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuoteBindingSource)).EndInit();
            this.RecentQuoteToolStrip.ResumeLayout(false);
            this.RecentQuoteToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuoteLengthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView RecentQuoteGridView;
        private System.Windows.Forms.ToolStrip RecentQuoteToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.ToolStripComboBox QuoteFrequencyComboBox;
        private System.Windows.Forms.ToolStripLabel QuoteLengthToolLabel;
        private System.Windows.Forms.NumericUpDown QuoteLengthNumeric;
        private System.Windows.Forms.BindingSource RecentQuoteBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openningPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteFrequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton MLTransformButton;
    }
}