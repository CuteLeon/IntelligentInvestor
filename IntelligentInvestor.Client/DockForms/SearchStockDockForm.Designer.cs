namespace IntelligentInvestor.Client.DockForms
{
    partial class SearchStockDockForm
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
            this.SearchToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddSelectedStockToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveSelectedStockToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteRepositoryToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteHistoryStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolButton = new System.Windows.Forms.ToolStripButton();
            this.StockComboBox = new System.Windows.Forms.ComboBox();
            this.MainStockQuoteControl = new IntelligentInvestor.Client.Controls.StockQuoteControl();
            this.SearchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchToolStrip
            // 
            this.SearchToolStrip.Enabled = false;
            this.SearchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSelectedStockToolButton,
            this.RemoveSelectedStockToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.ChartToolButton,
            this.QuoteRepositoryToolButton,
            this.QuoteHistoryStripButton,
            this.toolStripSeparator2,
            this.SaveToolButton,
            this.DeleteToolButton});
            this.SearchToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SearchToolStrip.Name = "SearchToolStrip";
            this.SearchToolStrip.Size = new System.Drawing.Size(336, 25);
            this.SearchToolStrip.TabIndex = 8;
            this.SearchToolStrip.Text = "toolStrip1";
            // 
            // AddSelectedStockToolButton
            // 
            this.AddSelectedStockToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddSelectedStockToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Add;
            this.AddSelectedStockToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddSelectedStockToolButton.Name = "AddSelectedStockToolButton";
            this.AddSelectedStockToolButton.Size = new System.Drawing.Size(23, 22);
            this.AddSelectedStockToolButton.Text = "Select";
            this.AddSelectedStockToolButton.Click += this.AddSelectedStockToolButton_Click;
            // 
            // RemoveSelectedStockToolButton
            // 
            this.RemoveSelectedStockToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveSelectedStockToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Remove;
            this.RemoveSelectedStockToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveSelectedStockToolButton.Name = "RemoveSelectedStockToolButton";
            this.RemoveSelectedStockToolButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveSelectedStockToolButton.Text = "Unselect";
            this.RemoveSelectedStockToolButton.Click += this.RemoveSelectedStockToolButton_Click;
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Refresh;
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolButton.Text = "Refresh";
            this.RefreshToolButton.Click += this.RefreshToolButton_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ChartToolButton
            // 
            this.ChartToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChartToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Chart;
            this.ChartToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChartToolButton.Name = "ChartToolButton";
            this.ChartToolButton.Size = new System.Drawing.Size(23, 22);
            this.ChartToolButton.Text = "Chart";
            this.ChartToolButton.Click += this.ChartToolButton_Click;
            // 
            // QuoteRepositoryToolButton
            // 
            this.QuoteRepositoryToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuoteRepositoryToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Context;
            this.QuoteRepositoryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuoteRepositoryToolButton.Name = "QuoteRepositoryToolButton";
            this.QuoteRepositoryToolButton.Size = new System.Drawing.Size(23, 22);
            this.QuoteRepositoryToolButton.Text = "Quote Repository";
            this.QuoteRepositoryToolButton.Click += this.QuoteRepositoryToolButton_Click;
            // 
            // QuoteHistoryStripButton
            // 
            this.QuoteHistoryStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuoteHistoryStripButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Clock;
            this.QuoteHistoryStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuoteHistoryStripButton.Name = "QuoteHistoryStripButton";
            this.QuoteHistoryStripButton.Size = new System.Drawing.Size(23, 22);
            this.QuoteHistoryStripButton.Text = "Quote History";
            this.QuoteHistoryStripButton.Click += this.QuoteHistoryStripButton_Click;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveToolButton
            // 
            this.SaveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Save;
            this.SaveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolButton.Name = "SaveToolButton";
            this.SaveToolButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolButton.Text = "Save";
            this.SaveToolButton.Click += this.SaveToolButton_Click;
            // 
            // DeleteToolButton
            // 
            this.DeleteToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Delete;
            this.DeleteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolButton.Name = "DeleteToolButton";
            this.DeleteToolButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteToolButton.Text = "Remove";
            this.DeleteToolButton.Click += this.DeleteToolButton_Click;
            // 
            // StockComboBox
            // 
            this.StockComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.StockComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockComboBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StockComboBox.Location = new System.Drawing.Point(0, 25);
            this.StockComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.StockComboBox.MaxDropDownItems = 10;
            this.StockComboBox.Name = "StockComboBox";
            this.StockComboBox.Size = new System.Drawing.Size(336, 25);
            this.StockComboBox.TabIndex = 9;
            this.StockComboBox.KeyDown += this.StockComboBox_KeyDown;
            this.StockComboBox.SelectedValueChanged += this.StockComboBox_SelectedValueChanged;
            // 
            // MainStockQuoteControl
            // 
            this.MainStockQuoteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStockQuoteControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuoteControl.Location = new System.Drawing.Point(0, 50);
            this.MainStockQuoteControl.Margin = new System.Windows.Forms.Padding(5);
            this.MainStockQuoteControl.Name = "MainStockQuoteControl";
            this.MainStockQuoteControl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainStockQuoteControl.Size = new System.Drawing.Size(336, 434);
            this.MainStockQuoteControl.Stock = null;
            this.MainStockQuoteControl.TabIndex = 10;
            this.MainStockQuoteControl.ThemeHandler = null;
            this.MainStockQuoteControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // SearchStockDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 484);
            this.Controls.Add(this.MainStockQuoteControl);
            this.Controls.Add(this.StockComboBox);
            this.Controls.Add(this.SearchToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchStockDockForm";
            this.TabText = "Search";
            this.Text = "Search";
            this.SearchToolStrip.ResumeLayout(false);
            this.SearchToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ToolStrip SearchToolStrip;
        private ToolStripButton AddSelectedStockToolButton;
        private ToolStripButton RemoveSelectedStockToolButton;
        private ToolStripButton RefreshToolButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton ChartToolButton;
        private ToolStripButton QuoteRepositoryToolButton;
        private ToolStripButton QuoteHistoryStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton SaveToolButton;
        private ToolStripButton DeleteToolButton;
        private ComboBox StockComboBox;
        private Controls.StockQuoteControl MainStockQuoteControl;
    }
}