using IntelligentInvestor.Client.Themes;

namespace IntelligentInvestor.Client.DockForms
{
    partial class MarketIndexForm
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
            this.MarketIndexToolStrip = new System.Windows.Forms.ToolStrip();
            this.AutoRefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMarketIndexControl = new IntelligentInvestor.Client.Controls.MarketIndexControl(themeHandler);
            this.AutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.MarketIndexToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MarketIndexToolStrip
            // 
            this.MarketIndexToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoRefreshToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1});
            this.MarketIndexToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MarketIndexToolStrip.Name = "MarketIndexToolStrip";
            this.MarketIndexToolStrip.Size = new System.Drawing.Size(330, 25);
            this.MarketIndexToolStrip.TabIndex = 2;
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
            this.RefreshToolButton.Text = "Refresh Quote";
            this.RefreshToolButton.Click += new System.EventHandler(this.RefreshToolButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // MainMarketIndexControl
            // 
            this.MainMarketIndexControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMarketIndexControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainMarketIndexControl.Location = new System.Drawing.Point(0, 25);
            this.MainMarketIndexControl.Name = "MainMarketIndexControl";
            this.MainMarketIndexControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainMarketIndexControl.Size = new System.Drawing.Size(330, 197);
            this.MainMarketIndexControl.Stock = null;
            this.MainMarketIndexControl.TabIndex = 3;
            this.MainMarketIndexControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 5000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // MarketIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 222);
            this.Controls.Add(this.MainMarketIndexControl);
            this.Controls.Add(this.MarketIndexToolStrip);
            this.Name = "MarketIndexForm";
            this.TabText = "Market Index";
            this.Text = "Market Index";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarketIndexForm_FormClosed);
            this.Load += new System.EventHandler(this.MarketIndexForm_Load);
            this.MarketIndexToolStrip.ResumeLayout(false);
            this.MarketIndexToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip MarketIndexToolStrip;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.MarketIndexControl MainMarketIndexControl;
        private System.Windows.Forms.Timer AutoRefreshTimer;
    }
}