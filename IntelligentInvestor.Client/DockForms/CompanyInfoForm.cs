using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class CompanyInfoForm : SingleToolDockForm
{
    public CompanyInfoForm(
        ILogger<DockFormBase> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.CompanyInfoIcon;
    }
}
