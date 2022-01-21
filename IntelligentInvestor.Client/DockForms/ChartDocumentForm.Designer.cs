namespace IntelligentInvestor.Client.DockForms
{
    partial class ChartDocumentForm
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
            this.ChartRepositoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuoteFrequencyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.ChartPictureBox = new System.Windows.Forms.PictureBox();
            this.ChartRepositoryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartRepositoryToolStrip
            // 
            this.ChartRepositoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.QuoteFrequencyComboBox,
            this.toolStripSeparator2,
            this.RefreshToolButton});
            this.ChartRepositoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ChartRepositoryToolStrip.Name = "ChartRepositoryToolStrip";
            this.ChartRepositoryToolStrip.Size = new System.Drawing.Size(933, 25);
            this.ChartRepositoryToolStrip.TabIndex = 1;
            this.ChartRepositoryToolStrip.Text = "toolStrip1";
            // 
            // StockInfoToolLabel
            // 
            this.StockInfoToolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.QuoteFrequencyComboBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // ChartPictureBox
            // 
            this.ChartPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChartPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartPictureBox.Location = new System.Drawing.Point(0, 25);
            this.ChartPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChartPictureBox.Name = "ChartPictureBox";
            this.ChartPictureBox.Size = new System.Drawing.Size(933, 537);
            this.ChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ChartPictureBox.TabIndex = 2;
            this.ChartPictureBox.TabStop = false;
            // 
            // ChartDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.ChartPictureBox);
            this.Controls.Add(this.ChartRepositoryToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChartDocumentForm";
            this.TabText = "Chart";
            this.Text = "Chart";
            this.Shown += new System.EventHandler(this.ChartDocumentForm_Shown);
            this.ChartRepositoryToolStrip.ResumeLayout(false);
            this.ChartRepositoryToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.ToolStrip ChartRepositoryToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripComboBox QuoteFrequencyComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox ChartPictureBox;
    }
}