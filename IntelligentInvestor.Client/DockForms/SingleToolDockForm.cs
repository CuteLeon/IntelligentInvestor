using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class SingleToolDockForm : ToolDockForm
{
    public SingleToolDockForm(
        ILogger<SingleToolDockForm> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();
        this.HideOnClose = true;
    }
}
