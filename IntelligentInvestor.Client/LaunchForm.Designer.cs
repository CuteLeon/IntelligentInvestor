namespace IntelligentInvestor.Client
{
    partial class LaunchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MassageLabel = new System.Windows.Forms.Label();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MassageLabel
            // 
            this.MassageLabel.AutoEllipsis = true;
            this.MassageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MassageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MassageLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MassageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MassageLabel.Location = new System.Drawing.Point(0, 430);
            this.MassageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MassageLabel.Name = "MassageLabel";
            this.MassageLabel.Padding = new System.Windows.Forms.Padding(10);
            this.MassageLabel.Size = new System.Drawing.Size(718, 50);
            this.MassageLabel.TabIndex = 0;
            this.MassageLabel.Text = "Launching ...";
            this.MassageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogoLabel
            // 
            this.LogoLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LogoLabel.ForeColor = System.Drawing.Color.White;
            this.LogoLabel.Image = global::IntelligentInvestor.Client.IntelligentInvestorResource.IntelligentInvestorLogo;
            this.LogoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogoLabel.Location = new System.Drawing.Point(0, 0);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Padding = new System.Windows.Forms.Padding(180, 0, 180, 0);
            this.LogoLabel.Size = new System.Drawing.Size(718, 430);
            this.LogoLabel.TabIndex = 1;
            this.LogoLabel.Text = "Intelligent Investor";
            this.LogoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IntelligentInvestor.Client.IntelligentInvestorResource.LaunchBackgroud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 480);
            this.Controls.Add(this.LogoLabel);
            this.Controls.Add(this.MassageLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LaunchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntelligentInvestor Launching ...";
            this.ResumeLayout(false);

        }

        #endregion

        private Label MassageLabel;
        private Label LogoLabel;
    }
}