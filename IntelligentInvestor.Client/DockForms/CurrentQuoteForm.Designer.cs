﻿using IntelligentInvestor.Client.Themes;

namespace IntelligentInvestor.Client.DockForms
{
    partial class CurrentQuoteForm
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
            this.CurrentQuoteToolStrip = new System.Windows.Forms.ToolStrip();
            this.AutoRefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuoteRepositoryToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainStockQuoteControl = new IntelligentInvestor.Client.Controls.StockQuoteControl(themeHandler);
            this.MainFiveGearControl = new IntelligentInvestor.Client.Controls.StockQuoteFiveGearControl(themeHandler);
            this.RecentQuoteToolButton = new System.Windows.Forms.ToolStripButton();
            this.CurrentQuoteToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 3000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // CurrentQuoteToolStrip
            // 
            this.CurrentQuoteToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoRefreshToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.ChartToolButton,
            this.QuoteRepositoryToolButton,
            this.RecentQuoteToolButton});
            this.CurrentQuoteToolStrip.Location = new System.Drawing.Point(0, 0);
            this.CurrentQuoteToolStrip.Name = "CurrentQuoteToolStrip";
            this.CurrentQuoteToolStrip.Size = new System.Drawing.Size(349, 25);
            this.CurrentQuoteToolStrip.TabIndex = 1;
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
            // ChartToolButton
            // 
            this.ChartToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChartToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Quote;
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
            // MainStockQuoteControl
            // 
            this.MainStockQuoteControl.AttachEntity = null;
            this.MainStockQuoteControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainStockQuoteControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuoteControl.Location = new System.Drawing.Point(0, 25);
            this.MainStockQuoteControl.Name = "MainStockQuoteControl";
            this.MainStockQuoteControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainStockQuoteControl.Size = new System.Drawing.Size(349, 185);
            this.MainStockQuoteControl.Stock = null;
            this.MainStockQuoteControl.TabIndex = 2;
            this.MainStockQuoteControl.ValueForecolor = System.Drawing.Color.Empty;
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
            // RecentQuoteToolButton
            // 
            this.RecentQuoteToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RecentQuoteToolButton.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.Clock;
            this.RecentQuoteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RecentQuoteToolButton.Name = "RecentQuoteToolButton";
            this.RecentQuoteToolButton.Size = new System.Drawing.Size(23, 22);
            this.RecentQuoteToolButton.Text = "Recent Quote";
            this.RecentQuoteToolButton.Click += new System.EventHandler(this.RecentQuoteToolButton_Click);
            // 
            // CurrentQuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 361);
            this.Controls.Add(this.MainFiveGearControl);
            this.Controls.Add(this.MainStockQuoteControl);
            this.Controls.Add(this.CurrentQuoteToolStrip);
            this.Name = "CurrentQuoteForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Trade Quote";
            this.Text = "Trade Quote";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentQuoteForm_FormClosed);
            this.Load += new System.EventHandler(this.CurrentQuoteForm_Load);
            this.CurrentQuoteToolStrip.ResumeLayout(false);
            this.CurrentQuoteToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer AutoRefreshTimer;
        private System.Windows.Forms.ToolStrip CurrentQuoteToolStrip;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripButton QuoteRepositoryToolButton;
        private System.Windows.Forms.ToolStripButton ChartToolButton;
        private Controls.StockQuoteControl MainStockQuoteControl;
        private Controls.StockQuoteFiveGearControl MainFiveGearControl;
        private System.Windows.Forms.ToolStripButton RecentQuoteToolButton;
    }
}