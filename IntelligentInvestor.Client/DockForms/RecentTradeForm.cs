using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class RecentTradeForm : SingleToolDockForm
{
    public RecentTradeForm(
        ILogger<RecentTradeForm> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.RecentTradeIcon;
    }
}
