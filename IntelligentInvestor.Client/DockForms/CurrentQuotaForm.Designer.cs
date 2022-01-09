using IntelligentInvestor.Client.Themes;

namespace IntelligentInvestor.Client.DockForms
{
    partial class CurrentQuotaForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentQuotaToolStrip = new System.Windows.Forms.ToolStrip();
            this.AutoRefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaRepositoryToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainStockQuotaControl = new IntelligentInvestor.Client.Controls.StockQuotaControl(themeHandler);
            this.MainFiveGearControl = new IntelligentInvestor.Client.Controls.StockQuotaFiveGearControl(themeHandler);
            this.RecentQuotaToolButton = new System.Windows.Forms.ToolStripButton();
            this.CurrentQuotaToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 3000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // CurrentQuotaToolStrip
            // 
            this.CurrentQuotaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoRefreshToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.ChartToolButton,
            this.QuotaRepositoryToolButton,
            this.RecentQuotaToolButton});
            this.CurrentQuotaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.CurrentQuotaToolStrip.Name = "CurrentQuotaToolStrip";
            this.CurrentQuotaToolStrip.Size = new System.Drawing.Size(349, 25);
            this.CurrentQuotaToolStrip.TabIndex = 1;
            // 
            // AutoRefreshToolButton
            // 
            this.AutoRefreshToolButton.Checked = true;
            this.AutoRefreshToolButton.CheckOnClick = true;
            this.AutoRefreshToolButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AutoRefreshToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Service;
            this.AutoRefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoRefreshToolButton.Name = "AutoRefreshToolButton";
            this.AutoRefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.AutoRefreshToolButton.Text = "Auto Refresh";
            this.AutoRefreshToolButton.CheckedChanged += new System.EventHandler(this.AutoRefreshToolButton_CheckedChanged);
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Refresh;
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolButton.Text = "Refresh Quota";
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
            this.ChartToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Quota;
            this.ChartToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChartToolButton.Name = "ChartToolButton";
            this.ChartToolButton.Size = new System.Drawing.Size(23, 22);
            this.ChartToolButton.Text = "Chart";
            this.ChartToolButton.Click += new System.EventHandler(this.ChartToolButton_Click);
            // 
            // QuotaRepositoryToolButton
            // 
            this.QuotaRepositoryToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuotaRepositoryToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Context;
            this.QuotaRepositoryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuotaRepositoryToolButton.Name = "QuotaRepositoryToolButton";
            this.QuotaRepositoryToolButton.Size = new System.Drawing.Size(23, 22);
            this.QuotaRepositoryToolButton.Text = "Quota Repository";
            this.QuotaRepositoryToolButton.Click += new System.EventHandler(this.QuotaRepositoryToolButton_Click);
            // 
            // MainStockQuotaControl
            // 
            this.MainStockQuotaControl.AttachEntity = null;
            this.MainStockQuotaControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainStockQuotaControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuotaControl.Location = new System.Drawing.Point(0, 25);
            this.MainStockQuotaControl.Name = "MainStockQuotaControl";
            this.MainStockQuotaControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainStockQuotaControl.Size = new System.Drawing.Size(349, 185);
            this.MainStockQuotaControl.Stock = null;
            this.MainStockQuotaControl.TabIndex = 2;
            this.MainStockQuotaControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // MainFiveGearControl
            // 
            this.MainFiveGearControl.AttachEntity = null;
            this.MainFiveGearControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainFiveGearControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainFiveGearControl.Location = new System.Drawing.Point(0, 210);
            this.MainFiveGearControl.Name = "MainFiveGearControl";
            this.MainFiveGearControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainFiveGearControl.Size = new System.Drawing.Size(349, 152);
            this.MainFiveGearControl.Stock = null;
            this.MainFiveGearControl.TabIndex = 3;
            this.MainFiveGearControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // RecentQuotaToolButton
            // 
            this.RecentQuotaToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RecentQuotaToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Clock;
            this.RecentQuotaToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RecentQuotaToolButton.Name = "RecentQuotaToolButton";
            this.RecentQuotaToolButton.Size = new System.Drawing.Size(23, 22);
            this.RecentQuotaToolButton.Text = "Recent Quota";
            this.RecentQuotaToolButton.Click += new System.EventHandler(this.RecentQuotaToolButton_Click);
            // 
            // CurrentQuotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 361);
            this.Controls.Add(this.MainFiveGearControl);
            this.Controls.Add(this.MainStockQuotaControl);
            this.Controls.Add(this.CurrentQuotaToolStrip);
            this.Name = "CurrentQuotaForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Trade Quota";
            this.Text = "Trade Quota";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentQuotaForm_FormClosed);
            this.Load += new System.EventHandler(this.CurrentQuotaForm_Load);
            this.CurrentQuotaToolStrip.ResumeLayout(false);
            this.CurrentQuotaToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer AutoRefreshTimer;
        private System.Windows.Forms.ToolStrip CurrentQuotaToolStrip;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripButton QuotaRepositoryToolButton;
        private System.Windows.Forms.ToolStripButton ChartToolButton;
        private Controls.StockQuotaControl MainStockQuotaControl;
        private Controls.StockQuotaFiveGearControl MainFiveGearControl;
        private System.Windows.Forms.ToolStripButton RecentQuotaToolButton;
    }
}