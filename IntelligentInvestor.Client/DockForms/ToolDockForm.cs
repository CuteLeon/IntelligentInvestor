using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class ToolDockForm : DockFormBase
{
    public ToolDockForm(
        ILogger<ToolDockForm> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();
    }
}
