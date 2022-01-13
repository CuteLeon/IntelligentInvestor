namespace IntelligentInvestor.Client.Controls
{
    partial class MarketQuoteControl
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
            this.MarketValueLabel = new System.Windows.Forms.Label();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.CodeValueLabel = new System.Windows.Forms.Label();
            this.QuoteTimeLabel = new System.Windows.Forms.Label();
            this.QuoteTimeValueLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountValueLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountValueLabel = new System.Windows.Forms.Label();
            this.FluctuatingRateValueLabel = new System.Windows.Forms.Label();
            this.FluctuatingRangeValueLabel = new System.Windows.Forms.Label();
            this.CurrentPriceValueLabel = new System.Windows.Forms.Label();
            this.StockNameValueLabel = new System.Windows.Forms.Label();
            this.SeparatorLabel1 = new System.Windows.Forms.Label();
            this.MainTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MarketValueLabel
            // 
            this.MarketValueLabel.AutoEllipsis = true;
            this.MarketValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketValueLabel.Location = new System.Drawing.Point(188, 20);
            this.MarketValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarketValueLabel.Name = "MarketValueLabel";
            this.MarketValueLabel.Size = new System.Drawing.Size(81, 20);
            this.MarketValueLabel.TabIndex = 30;
            this.MarketValueLabel.Text = "-";
            this.MarketValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.AutoScroll = true;
            this.MainTablePanel.ColumnCount = 3;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTablePanel.Controls.Add(this.MarketValueLabel, 2, 1);
            this.MainTablePanel.Controls.Add(this.CodeValueLabel, 2, 0);
            this.MainTablePanel.Controls.Add(this.QuoteTimeLabel, 2, 4);
            this.MainTablePanel.Controls.Add(this.QuoteTimeValueLabel, 2, 5);
            this.MainTablePanel.Controls.Add(this.AmountLabel, 1, 4);
            this.MainTablePanel.Controls.Add(this.AmountValueLabel, 1, 5);
            this.MainTablePanel.Controls.Add(this.CountLabel, 0, 4);
            this.MainTablePanel.Controls.Add(this.CountValueLabel, 0, 5);
            this.MainTablePanel.Controls.Add(this.FluctuatingRateValueLabel, 1, 2);
            this.MainTablePanel.Controls.Add(this.FluctuatingRangeValueLabel, 0, 2);
            this.MainTablePanel.Controls.Add(this.CurrentPriceValueLabel, 0, 0);
            this.MainTablePanel.Controls.Add(this.StockNameValueLabel, 2, 2);
            this.MainTablePanel.Controls.Add(this.SeparatorLabel1, 0, 3);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(3, 3);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 7;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(269, 116);
            this.MainTablePanel.TabIndex = 2;
            // 
            // CodeValueLabel
            // 
            this.CodeValueLabel.AutoEllipsis = true;
            this.CodeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeValueLabel.Location = new System.Drawing.Point(188, 0);
            this.CodeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CodeValueLabel.Name = "CodeValueLabel";
            this.CodeValueLabel.Size = new System.Drawing.Size(81, 20);
            this.CodeValueLabel.TabIndex = 28;
            this.CodeValueLabel.Text = "-";
            this.CodeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuoteTimeLabel
            // 
            this.QuoteTimeLabel.AutoEllipsis = true;
            this.QuoteTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuoteTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.QuoteTimeLabel.Location = new System.Drawing.Point(188, 65);
            this.QuoteTimeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteTimeLabel.Name = "QuoteTimeLabel";
            this.QuoteTimeLabel.Size = new System.Drawing.Size(81, 18);
            this.QuoteTimeLabel.TabIndex = 26;
            this.QuoteTimeLabel.Text = "Quote Time";
            this.QuoteTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // QuoteTimeValueLabel
            // 
            this.QuoteTimeValueLabel.AutoEllipsis = true;
            this.QuoteTimeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuoteTimeValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuoteTimeValueLabel.Location = new System.Drawing.Point(188, 83);
            this.QuoteTimeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.QuoteTimeValueLabel.Name = "QuoteTimeValueLabel";
            this.QuoteTimeValueLabel.Size = new System.Drawing.Size(81, 20);
            this.QuoteTimeValueLabel.TabIndex = 25;
            this.QuoteTimeValueLabel.Text = "-";
            this.QuoteTimeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoEllipsis = true;
            this.AmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.AmountLabel.Location = new System.Drawing.Point(94, 65);
            this.AmountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(94, 18);
            this.AmountLabel.TabIndex = 24;
            this.AmountLabel.Text = "Amount";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AmountValueLabel
            // 
            this.AmountValueLabel.AutoEllipsis = true;
            this.AmountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AmountValueLabel.Location = new System.Drawing.Point(94, 83);
            this.AmountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountValueLabel.Name = "AmountValueLabel";
            this.AmountValueLabel.Size = new System.Drawing.Size(94, 20);
            this.AmountValueLabel.TabIndex = 23;
            this.AmountValueLabel.Text = "-";
            this.AmountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CountLabel
            // 
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.CountLabel.Location = new System.Drawing.Point(0, 65);
            this.CountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(94, 18);
            this.CountLabel.TabIndex = 22;
            this.CountLabel.Text = "Volumn";
            this.CountLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CountValueLabel
            // 
            this.CountValueLabel.AutoEllipsis = true;
            this.CountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountValueLabel.Location = new System.Drawing.Point(0, 83);
            this.CountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountValueLabel.Name = "CountValueLabel";
            this.CountValueLabel.Size = new System.Drawing.Size(94, 20);
            this.CountValueLabel.TabIndex = 21;
            this.CountValueLabel.Text = "-";
            this.CountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FluctuatingRateValueLabel
            // 
            this.FluctuatingRateValueLabel.AutoEllipsis = true;
            this.FluctuatingRateValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRateValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRateValueLabel.Location = new System.Drawing.Point(94, 40);
            this.FluctuatingRateValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRateValueLabel.Name = "FluctuatingRateValueLabel";
            this.FluctuatingRateValueLabel.Size = new System.Drawing.Size(94, 20);
            this.FluctuatingRateValueLabel.TabIndex = 15;
            this.FluctuatingRateValueLabel.Text = "-";
            this.FluctuatingRateValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FluctuatingRangeValueLabel
            // 
            this.FluctuatingRangeValueLabel.AutoEllipsis = true;
            this.FluctuatingRangeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRangeValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRangeValueLabel.Location = new System.Drawing.Point(0, 40);
            this.FluctuatingRangeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRangeValueLabel.Name = "FluctuatingRangeValueLabel";
            this.FluctuatingRangeValueLabel.Size = new System.Drawing.Size(94, 20);
            this.FluctuatingRangeValueLabel.TabIndex = 13;
            this.FluctuatingRangeValueLabel.Text = "-";
            this.FluctuatingRangeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentPriceValueLabel
            // 
            this.CurrentPriceValueLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.CurrentPriceValueLabel, 2);
            this.CurrentPriceValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPriceValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold);
            this.CurrentPriceValueLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentPriceValueLabel.Location = new System.Drawing.Point(0, 0);
            this.CurrentPriceValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentPriceValueLabel.Name = "CurrentPriceValueLabel";
            this.MainTablePanel.SetRowSpan(this.CurrentPriceValueLabel, 2);
            this.CurrentPriceValueLabel.Size = new System.Drawing.Size(188, 40);
            this.CurrentPriceValueLabel.TabIndex = 11;
            this.CurrentPriceValueLabel.Text = "-";
            this.CurrentPriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StockNameValueLabel
            // 
            this.StockNameValueLabel.AutoEllipsis = true;
            this.StockNameValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockNameValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockNameValueLabel.Location = new System.Drawing.Point(188, 40);
            this.StockNameValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StockNameValueLabel.Name = "StockNameValueLabel";
            this.StockNameValueLabel.Size = new System.Drawing.Size(81, 20);
            this.StockNameValueLabel.TabIndex = 10;
            this.StockNameValueLabel.Text = "-";
            this.StockNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeparatorLabel1
            // 
            this.SeparatorLabel1.AutoSize = true;
            this.SeparatorLabel1.BackColor = System.Drawing.Color.Gray;
            this.MainTablePanel.SetColumnSpan(this.SeparatorLabel1, 3);
            this.SeparatorLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeparatorLabel1.Location = new System.Drawing.Point(10, 62);
            this.SeparatorLabel1.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.SeparatorLabel1.Name = "SeparatorLabel1";
            this.SeparatorLabel1.Size = new System.Drawing.Size(249, 1);
            this.SeparatorLabel1.TabIndex = 31;
            // 
            // MarketQuoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTablePanel);
            this.Name = "MarketQuoteControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(275, 122);
            this.MainTablePanel.ResumeLayout(false);
            this.MainTablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label MarketValueLabel;
        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.Label CodeValueLabel;
        private System.Windows.Forms.Label QuoteTimeLabel;
        private System.Windows.Forms.Label QuoteTimeValueLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label AmountValueLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label CountValueLabel;
        private System.Windows.Forms.Label FluctuatingRateValueLabel;
        private System.Windows.Forms.Label FluctuatingRangeValueLabel;
        private System.Windows.Forms.Label CurrentPriceValueLabel;
        private System.Windows.Forms.Label StockNameValueLabel;
        private System.Windows.Forms.Label SeparatorLabel1;
    }
}
