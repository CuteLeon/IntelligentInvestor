namespace IntelligentInvestor.Client.DockForms
{
    partial class RecentQuotaDocumentForm
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
            this.RecentQuotaGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openningPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecentQuotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecentQuotaToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimeScaleToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.TimeScaleToolComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.QuotaLengthToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.MLTransformButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaBindingSource)).BeginInit();
            this.RecentQuotaToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaLengthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // RecentQuotaGridView
            // 
            this.RecentQuotaGridView.AllowUserToAddRows = false;
            this.RecentQuotaGridView.AllowUserToDeleteRows = false;
            this.RecentQuotaGridView.AllowUserToOrderColumns = true;
            this.RecentQuotaGridView.AllowUserToResizeRows = false;
            this.RecentQuotaGridView.AutoGenerateColumns = false;
            this.RecentQuotaGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RecentQuotaGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecentQuotaGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RecentQuotaGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuotaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecentQuotaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.openningPriceDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.highestPriceDataGridViewTextBoxColumn,
            this.lowestPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn});
            this.RecentQuotaGridView.DataSource = this.RecentQuotaBindingSource;
            this.RecentQuotaGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentQuotaGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RecentQuotaGridView.Location = new System.Drawing.Point(0, 25);
            this.RecentQuotaGridView.Name = "RecentQuotaGridView";
            this.RecentQuotaGridView.ReadOnly = true;
            this.RecentQuotaGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuotaGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RecentQuotaGridView.RowTemplate.Height = 23;
            this.RecentQuotaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecentQuotaGridView.Size = new System.Drawing.Size(522, 324);
            this.RecentQuotaGridView.TabIndex = 3;
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
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockName);
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 54;
            // 
            // openningPriceDataGridViewTextBoxColumn
            // 
            this.openningPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.OpenningPrice);
            this.openningPriceDataGridViewTextBoxColumn.HeaderText = "Open Price";
            this.openningPriceDataGridViewTextBoxColumn.Name = "openningPriceDataGridViewTextBoxColumn";
            this.openningPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openningPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // closingPriceDataGridViewTextBoxColumn
            // 
            this.closingPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.ClosingPrice);
            this.closingPriceDataGridViewTextBoxColumn.HeaderText = "Close Price";
            this.closingPriceDataGridViewTextBoxColumn.Name = "closingPriceDataGridViewTextBoxColumn";
            this.closingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // highestPriceDataGridViewTextBoxColumn
            // 
            this.highestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.HighestPrice);
            this.highestPriceDataGridViewTextBoxColumn.HeaderText = "Highest Price";
            this.highestPriceDataGridViewTextBoxColumn.Name = "highestPriceDataGridViewTextBoxColumn";
            this.highestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.highestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // lowestPriceDataGridViewTextBoxColumn
            // 
            this.lowestPriceDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.LowestPrice);
            this.lowestPriceDataGridViewTextBoxColumn.HeaderText = "Lowest Price";
            this.lowestPriceDataGridViewTextBoxColumn.Name = "lowestPriceDataGridViewTextBoxColumn";
            this.lowestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowestPriceDataGridViewTextBoxColumn.Width = 90;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.Quota.Volume);
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volumn";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 66;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Quotas.QuotaBase.QuotaTime);
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.updateTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "Quota Time";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTimeDataGridViewTextBoxColumn.Width = 78;
            // 
            // RecentQuotaBindingSource
            // 
            this.RecentQuotaBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Quotas.Quota);
            // 
            // RecentQuotaToolStrip
            // 
            this.RecentQuotaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.TimeScaleToolLabel,
            this.TimeScaleToolComboBox,
            this.QuotaLengthToolLabel,
            this.toolStripSeparator2,
            this.ExportToolButton,
            this.MLTransformButton,
            this.toolStripSeparator3,
            this.QueryToolButton});
            this.RecentQuotaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.RecentQuotaToolStrip.Name = "RecentQuotaToolStrip";
            this.RecentQuotaToolStrip.Size = new System.Drawing.Size(522, 25);
            this.RecentQuotaToolStrip.TabIndex = 2;
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
            // TimeScaleToolLabel
            // 
            this.TimeScaleToolLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TimeScaleToolLabel.Name = "TimeScaleToolLabel";
            this.TimeScaleToolLabel.Size = new System.Drawing.Size(56, 22);
            this.TimeScaleToolLabel.Text = "Frequency";
            // 
            // TimeScaleToolComboBox
            // 
            this.TimeScaleToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScaleToolComboBox.Name = "TimeScaleToolComboBox";
            this.TimeScaleToolComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // QuotaLengthToolLabel
            // 
            this.QuotaLengthToolLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuotaLengthToolLabel.Name = "QuotaLengthToolLabel";
            this.QuotaLengthToolLabel.Size = new System.Drawing.Size(56, 22);
            this.QuotaLengthToolLabel.Text = "Count";
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
            // QuotaLengthNumeric
            // 
            this.QuotaLengthNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuotaLengthNumeric.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaLengthNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Location = new System.Drawing.Point(224, 149);
            this.QuotaLengthNumeric.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Name = "QuotaLengthNumeric";
            this.QuotaLengthNumeric.Size = new System.Drawing.Size(120, 22);
            this.QuotaLengthNumeric.TabIndex = 4;
            this.QuotaLengthNumeric.Value = new decimal(new int[] {
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
            // RecentQuotaDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 349);
            this.Controls.Add(this.QuotaLengthNumeric);
            this.Controls.Add(this.RecentQuotaGridView);
            this.Controls.Add(this.RecentQuotaToolStrip);
            this.Name = "RecentQuotaDocumentForm";
            this.TabText = "RecentQuotaDocumentForm";
            this.Text = "RecentQuotaDocumentForm";
            this.Load += new System.EventHandler(this.RecentQuotaDocumentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaBindingSource)).EndInit();
            this.RecentQuotaToolStrip.ResumeLayout(false);
            this.RecentQuotaToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaLengthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView RecentQuotaGridView;
        private System.Windows.Forms.ToolStrip RecentQuotaToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.ToolStripLabel TimeScaleToolLabel;
        private System.Windows.Forms.ToolStripComboBox TimeScaleToolComboBox;
        private System.Windows.Forms.ToolStripLabel QuotaLengthToolLabel;
        private System.Windows.Forms.NumericUpDown QuotaLengthNumeric;
        private System.Windows.Forms.BindingSource RecentQuotaBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openningPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton MLTransformButton;
    }
}