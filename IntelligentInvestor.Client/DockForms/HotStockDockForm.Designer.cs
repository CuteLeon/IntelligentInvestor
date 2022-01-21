namespace IntelligentInvestor.Client.DockForms
{
    partial class HotStockDockForm
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
            this.HotStocksGridView = new System.Windows.Forms.DataGridView();
            this.HotStocksToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.HotStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.HotStocksGridView)).BeginInit();
            this.HotStocksToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HotStockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HotStocksGridView
            // 
            this.HotStocksGridView.AllowUserToAddRows = false;
            this.HotStocksGridView.AllowUserToDeleteRows = false;
            this.HotStocksGridView.AllowUserToOrderColumns = true;
            this.HotStocksGridView.AllowUserToResizeColumns = false;
            this.HotStocksGridView.AllowUserToResizeRows = false;
            this.HotStocksGridView.AutoGenerateColumns = false;
            this.HotStocksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HotStocksGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.HotStocksGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HotStocksGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HotStocksGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.HotStocksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HotStocksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.HotStocksGridView.DataSource = this.HotStockBindingSource;
            this.HotStocksGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotStocksGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.HotStocksGridView.Location = new System.Drawing.Point(0, 25);
            this.HotStocksGridView.MultiSelect = false;
            this.HotStocksGridView.Name = "HotStocksGridView";
            this.HotStocksGridView.ReadOnly = true;
            this.HotStocksGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.HotStocksGridView.RowHeadersVisible = false;
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HotStocksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HotStocksGridView.Size = new System.Drawing.Size(269, 272);
            this.HotStocksGridView.TabIndex = 3;
            // 
            // HotStocksToolStrip
            // 
            this.HotStocksToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolButton,
            this.RemoveToolButton,
            this.RefreshToolButton});
            this.HotStocksToolStrip.Location = new System.Drawing.Point(0, 0);
            this.HotStocksToolStrip.Name = "HotStocksToolStrip";
            this.HotStocksToolStrip.Size = new System.Drawing.Size(269, 25);
            this.HotStocksToolStrip.TabIndex = 2;
            // 
            // AddToolButton
            // 
            this.AddToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Add;
            this.AddToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolButton.Name = "AddToolButton";
            this.AddToolButton.Size = new System.Drawing.Size(23, 22);
            this.AddToolButton.Text = "Add";
            this.AddToolButton.Click += new System.EventHandler(this.AddToolButton_Click);
            // 
            // RemoveToolButton
            // 
            this.RemoveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Remove;
            this.RemoveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveToolButton.Name = "RemoveToolButton";
            this.RemoveToolButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveToolButton.Text = "Remove";
            this.RemoveToolButton.Click += new System.EventHandler(this.RemoveToolButton_Click);
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Refresh;
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolButton.Text = "Refresh";
            this.RefreshToolButton.Click += new System.EventHandler(this.RefreshToolButton_Click);
            // 
            // HotStockBindingSource
            // 
            this.HotStockBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Stocks.Stock);
            this.HotStockBindingSource.CurrentChanged += new EventHandler(this.HotStockBindingSource_CurrentChanged);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.HeaderText = "Market";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // HotStockDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 297);
            this.Controls.Add(this.HotStocksGridView);
            this.Controls.Add(this.HotStocksToolStrip);
            this.Name = "HotStockDockForm";
            this.TabText = "Hot Stocks";
            this.Text = "Hot Stocks";
            this.Shown += new System.EventHandler(this.HotStockDockForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HotStocksGridView)).EndInit();
            this.HotStocksToolStrip.ResumeLayout(false);
            this.HotStocksToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HotStockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView HotStocksGridView;
        private System.Windows.Forms.ToolStrip HotStocksToolStrip;
        private System.Windows.Forms.ToolStripButton AddToolButton;
        private System.Windows.Forms.ToolStripButton RemoveToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource HotStockBindingSource;
    }
}