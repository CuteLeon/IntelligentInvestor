using IntelligentInvestor.Client.Themes;

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

        private void InitializeComponent(IUIThemeHandler themeHandler)
        {
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.StockComboBox = new System.Windows.Forms.ComboBox();
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
            this.MainStockQuoteControl = new IntelligentInvestor.Client.Controls.StockQuoteControl(themeHandler);
            this.MainTablePanel.SuspendLayout();
            this.SearchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.StockComboBox, 0, 0);
            this.MainTablePanel.Controls.Add(this.SearchToolStrip, 0, 1);
            this.MainTablePanel.Controls.Add(this.MainStockQuoteControl, 0, 2);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 3;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.Size = new System.Drawing.Size(288, 387);
            this.MainTablePanel.TabIndex = 0;
            // 
            // StockComboBox
            // 
            this.MainTablePanel.SetColumnSpan(this.StockComboBox, 2);
            this.StockComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockComboBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockComboBox.Location = new System.Drawing.Point(0, 0);
            this.StockComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.StockComboBox.MaxDropDownItems = 10;
            this.StockComboBox.Name = "StockComboBox";
            this.StockComboBox.Size = new System.Drawing.Size(288, 25);
            this.StockComboBox.TabIndex = 6;
            this.StockComboBox.SelectedValueChanged += new System.EventHandler(this.StockComboBox_SelectedValueChanged);
            this.StockComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockComboBox_KeyDown);
            // 
            // SearchToolStrip
            // 
            this.MainTablePanel.SetColumnSpan(this.SearchToolStrip, 2);
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
            this.SearchToolStrip.Location = new System.Drawing.Point(0, 25);
            this.SearchToolStrip.Name = "SearchToolStrip";
            this.SearchToolStrip.Size = new System.Drawing.Size(288, 25);
            this.SearchToolStrip.TabIndex = 7;
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
            this.AddSelectedStockToolButton.Click += new System.EventHandler(this.AddSelectedStockToolButton_Click);
            // 
            // RemoveSelectedStockToolButton
            // 
            this.RemoveSelectedStockToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveSelectedStockToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Remove;
            this.RemoveSelectedStockToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveSelectedStockToolButton.Name = "RemoveSelectedStockToolButton";
            this.RemoveSelectedStockToolButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveSelectedStockToolButton.Text = "Unselect";
            this.RemoveSelectedStockToolButton.Click += new System.EventHandler(this.RemoveSelectedStockToolButton_Click);
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
            // ChartToolButton
            // 
            this.ChartToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChartToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Chart;
            this.ChartToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChartToolButton.Name = "ChartToolButton";
            this.ChartToolButton.Size = new System.Drawing.Size(23, 22);
            this.ChartToolButton.Text = "Chart";
            this.ChartToolButton.Click += new System.EventHandler(this.ChartToolButton_Click);
            // 
            // QuoteRepositoryToolButton
            // 
            this.QuoteRepositoryToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuoteRepositoryToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Context;
            this.QuoteRepositoryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuoteRepositoryToolButton.Name = "QuoteRepositoryToolButton";
            this.QuoteRepositoryToolButton.Size = new System.Drawing.Size(23, 22);
            this.QuoteRepositoryToolButton.Text = "Quote Repository";
            this.QuoteRepositoryToolButton.Click += new System.EventHandler(this.QuoteRepositoryToolButton_Click);
            // 
            // QuoteHistoryStripButton
            // 
            this.QuoteHistoryStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuoteHistoryStripButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Clock;
            this.QuoteHistoryStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuoteHistoryStripButton.Name = "QuoteHistoryStripButton";
            this.QuoteHistoryStripButton.Size = new System.Drawing.Size(23, 22);
            this.QuoteHistoryStripButton.Text = "Quote History";
            this.QuoteHistoryStripButton.Click += new System.EventHandler(this.QuoteHistoryStripButton_Click);
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
            this.SaveToolButton.Click += new System.EventHandler(this.SaveToolButton_Click);
            // 
            // DeleteToolButton
            // 
            this.DeleteToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Delete;
            this.DeleteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolButton.Name = "DeleteToolButton";
            this.DeleteToolButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteToolButton.Text = "Remove";
            this.DeleteToolButton.Click += new System.EventHandler(this.DeleteToolButton_Click);
            // 
            // MainStockQuoteControl
            // 
            this.MainStockQuoteControl.AttachEntity = null;
            this.MainTablePanel.SetColumnSpan(this.MainStockQuoteControl, 2);
            this.MainStockQuoteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStockQuoteControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuoteControl.Location = new System.Drawing.Point(3, 53);
            this.MainStockQuoteControl.Name = "MainStockQuoteControl";
            this.MainStockQuoteControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainStockQuoteControl.Size = new System.Drawing.Size(282, 331);
            this.MainStockQuoteControl.Stock = null;
            this.MainStockQuoteControl.TabIndex = 8;
            this.MainStockQuoteControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // SearchStockDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 387);
            this.Controls.Add(this.MainTablePanel);
            this.Name = "SearchStockDockForm";
            this.TabText = "Search";
            this.Text = "Search";
            this.MainTablePanel.ResumeLayout(false);
            this.MainTablePanel.PerformLayout();
            this.SearchToolStrip.ResumeLayout(false);
            this.SearchToolStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.ComboBox StockComboBox;
        private System.Windows.Forms.ToolStrip SearchToolStrip;
        private System.Windows.Forms.ToolStripButton AddSelectedStockToolButton;
        private System.Windows.Forms.ToolStripButton RemoveSelectedStockToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SaveToolButton;
        private System.Windows.Forms.ToolStripButton DeleteToolButton;
        private Controls.StockQuoteControl MainStockQuoteControl;
        private System.Windows.Forms.ToolStripButton ChartToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QuoteRepositoryToolButton;
        private System.Windows.Forms.ToolStripButton QuoteHistoryStripButton;
    }
}