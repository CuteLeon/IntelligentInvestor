using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace IntelligentInvestor.Client.DockForms.FloatWindows;

public class FloatedWindowFactory : IFloatWindowFactory
{
    public static FloatedWindowFactory SingleInstance { get; } = new FloatedWindowFactory();

    public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
    {
        return new FloatedWindow(dockPanel, pane, bounds);
    }

    public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
    {
        return new FloatedWindow(dockPanel, pane);
    }
}
