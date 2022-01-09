using WeifenLuo.WinFormsUI.Docking;

namespace IntelligentInvestor.Client.DockForms.FloatWindows;

public class FloatedWindow : FloatWindow
{
    public FloatedWindow(DockPanel dockPanel, DockPane pane)
        : base(dockPanel, pane)
    {
        this.CustomeStyle();
    }

    public FloatedWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
        : base(dockPanel, pane, bounds)
    {
        this.CustomeStyle();
    }

    protected virtual void CustomeStyle()
    {
        this.Icon = IntelligentInvestorResource.IntelligentInvestor;
        this.ShowIcon = true;
        this.ShowInTaskbar = true;
        this.FormBorderStyle = FormBorderStyle.Sizable;
    }
}
