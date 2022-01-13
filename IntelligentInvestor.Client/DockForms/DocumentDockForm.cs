using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class DocumentDockForm : DockFormBase
{
    public DocumentDockForm(
        ILogger<DocumentDockForm> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.DocumentIcon;
    }
}
