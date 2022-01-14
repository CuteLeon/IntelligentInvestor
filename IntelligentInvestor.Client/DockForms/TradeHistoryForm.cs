using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client.DockForms;

public partial class TradeHistoryForm : SingleToolDockForm
{
    public TradeHistoryForm(
        ILogger<TradeHistoryForm> logger,
        IUIThemeHandler themeHandler)
        : base(logger, themeHandler)
    {
        this.InitializeComponent();

        this.Icon = IntelligentInvestorResource.TradeHistoryIcon;
    }
}
