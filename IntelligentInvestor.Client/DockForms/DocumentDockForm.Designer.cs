using WeifenLuo.WinFormsUI.Docking;

namespace IntelligentInvestor.Client.DockForms;

partial class DocumentDockForm
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
        this.SuspendLayout();
        // 
        // DocumentDockForm
        // 
        this.DockAreas = DockAreas.Document | DockAreas.Float;
        this.ShowHint = DockState.Document;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Name = "DocumentDockForm";
        this.TabText = "Document";
        this.Text = "Document";
        this.ResumeLayout(false);
    }
}
