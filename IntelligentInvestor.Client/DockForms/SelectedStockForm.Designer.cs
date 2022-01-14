namespace IntelligentInvestor.Client.DockForms
{
    partial class SelectedStockForm
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
            this.SelectedStockStockToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchToolTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SelectedStockStockGridView = new System.Windows.Forms.DataGridView();
            this.StockCodeGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMarketGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNameGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedStockStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SelectedStockGridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedStockStockToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedStockStockGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedStockStockBindingSource)).BeginInit();
            this.SelectedStockGridViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedStockStockToolStrip
            // 
            this.SelectedStockStockToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolButton,
            this.RemoveToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.SearchToolTextBox});
            this.SelectedStockStockToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SelectedStockStockToolStrip.Name = "SelectedStockStockToolStrip";
            this.SelectedStockStockToolStrip.Size = new System.Drawing.Size(254, 25);
            this.SelectedStockStockToolStrip.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.SearchLabel;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SearchToolTextBox
            // 
            this.SearchToolTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SearchToolTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchToolTextBox.Name = "SearchToolTextBox";
            this.SearchToolTextBox.Size = new System.Drawing.Size(100, 25);
            this.SearchToolTextBox.TextChanged += new System.EventHandler(this.SearchToolTextBox_TextChanged);
            // 
            // SelectedStockStockGridView
            // 
            this.SelectedStockStockGridView.AllowUserToAddRows = false;
            this.SelectedStockStockGridView.AllowUserToDeleteRows = false;
            this.SelectedStockStockGridView.AllowUserToOrderColumns = true;
            this.SelectedStockStockGridView.AllowUserToResizeColumns = false;
            this.SelectedStockStockGridView.AllowUserToResizeRows = false;
            this.SelectedStockStockGridView.AutoGenerateColumns = false;
            this.SelectedStockStockGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectedStockStockGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SelectedStockStockGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedStockStockGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SelectedStockStockGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SelectedStockStockGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectedStockStockGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCodeGridViewColumn,
            this.StockMarketGridViewColumn,
            this.StockNameGridViewColumn});
            this.SelectedStockStockGridView.DataSource = this.SelectedStockStockBindingSource;
            this.SelectedStockStockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedStockStockGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SelectedStockStockGridView.Location = new System.Drawing.Point(0, 25);
            this.SelectedStockStockGridView.MultiSelect = false;
            this.SelectedStockStockGridView.Name = "SelectedStockStockGridView";
            this.SelectedStockStockGridView.ReadOnly = true;
            this.SelectedStockStockGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SelectedStockStockGridView.RowHeadersVisible = false;
            this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SelectedStockStockGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectedStockStockGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SelectedStockStockGridView.Size = new System.Drawing.Size(254, 256);
            this.SelectedStockStockGridView.TabIndex = 1;
            // 
            // StockCodeGridViewColumn
            // 
            this.StockCodeGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockCodeGridViewColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockCode);
            this.StockCodeGridViewColumn.HeaderText = "Code";
            this.StockCodeGridViewColumn.Name = "StockCodeGridViewColumn";
            this.StockCodeGridViewColumn.ReadOnly = true;
            // 
            // StockMarketGridViewColumn
            // 
            this.StockMarketGridViewColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.StockBase.StockMarket);
            this.StockMarketGridViewColumn.HeaderText = "Market";
            this.StockMarketGridViewColumn.Name = "StockMarketGridViewColumn";
            this.StockMarketGridViewColumn.ReadOnly = true;
            // 
            // StockNameGridViewColumn
            // 
            this.StockNameGridViewColumn.DataPropertyName = nameof(IntelligentInvestor.Domain.Stocks.Stock.StockName);
            this.StockNameGridViewColumn.HeaderText = "Name";
            this.StockNameGridViewColumn.Name = "StockNameGridViewColumn";
            this.StockNameGridViewColumn.ReadOnly = true;
            // 
            // SelectedStockStockBindingSource
            // 
            this.SelectedStockStockBindingSource.DataSource = typeof(IntelligentInvestor.Domain.Stocks.Stock);
            this.SelectedStockStockBindingSource.CurrentChanged += new EventHandler(this.SelectedStockStockBindingSource_CurrentChanged);
            // 
            // SelectedStockGridViewMenuStrip
            // 
            this.SelectedStockGridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMenuItem,
            this.RemoveMenuItem,
            this.RefreshMenuItem});
            this.SelectedStockGridViewMenuStrip.Name = "SelectedStockGridViewMenuStrip";
            this.SelectedStockGridViewMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // AddMenuItem
            // 
            this.AddMenuItem.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Add;
            this.AddMenuItem.Name = "AddMenuItem";
            this.AddMenuItem.Size = new System.Drawing.Size(100, 22);
            this.AddMenuItem.Text = "Add";
            this.AddMenuItem.Click += new System.EventHandler(this.AddMenuItem_Click);
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Remove;
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Size = new System.Drawing.Size(100, 22);
            this.RemoveMenuItem.Text = "Remove";
            this.RemoveMenuItem.Click += new System.EventHandler(this.RemoveMenuItem_Click);
            // 
            // RefreshMenuItem
            // 
            this.RefreshMenuItem.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Refresh;
            this.RefreshMenuItem.Name = "RefreshMenuItem";
            this.RefreshMenuItem.Size = new System.Drawing.Size(100, 22);
            this.RefreshMenuItem.Text = "Refresh";
            this.RefreshMenuItem.Click += new System.EventHandler(this.RefreshMenuItem_Click);
            // 
            // SelectedStockStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 281);
            this.Controls.Add(this.SelectedStockStockGridView);
            this.Controls.Add(this.SelectedStockStockToolStrip);
            this.DoubleBuffered = true;
            this.Name = "SelectedStockStockForm";
            this.TabText = "Selected";
            this.Text = "Selected";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectedStockStockForm_FormClosed);
            this.Load += new System.EventHandler(this.SelectedStockStockForm_Load);
            this.Shown += new System.EventHandler(this.SelectedStockStockForm_Shown);
            this.SelectedStockStockToolStrip.ResumeLayout(false);
            this.SelectedStockStockToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedStockStockGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedStockStockBindingSource)).EndInit();
            this.SelectedStockGridViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip SelectedStockStockToolStrip;
        private System.Windows.Forms.DataGridView SelectedStockStockGridView;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ContextMenuStrip SelectedStockGridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RefreshMenuItem;
        private System.Windows.Forms.ToolStripButton AddToolButton;
        private System.Windows.Forms.ToolStripButton RemoveToolButton;
        private System.Windows.Forms.ToolStripMenuItem AddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveMenuItem;
        private System.Windows.Forms.BindingSource SelectedStockStockBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCodeGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMarketGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNameGridViewColumn;
        private System.Windows.Forms.ToolStripTextBox SearchToolTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}