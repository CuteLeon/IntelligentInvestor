using IntelligentInvestor.Domain.Themes;
using WeifenLuo.WinFormsUI.Docking;

namespace IntelligentInvestor.Client.Themes;

public class UIThemeHandler : IUIThemeHandler
{
    public UIThemes CurrentTheme { get; set; } = UIThemes.Dark;

    public ThemeBase CurrentThemeComponent
    {
        get => this.CurrentTheme switch
        {
            UIThemes.Dark => new VS2015DarkTheme(),
            UIThemes.Blue => new VS2015BlueTheme(),
            UIThemes.Light => new VS2015LightTheme(),
            _ => new VS2015DarkTheme(),
        };
    }

    public ThemeBase SetTheme(UIThemes theme)
    {
        this.CurrentTheme = theme;
        return this.CurrentThemeComponent;
    }

    public Color GetContainerBackcolor()
        => CurrentThemeComponent.ColorPalette.ToolWindowTabSelectedActive.Background;

    public Color GetContentForecolor()
        => CurrentThemeComponent.ColorPalette.CommandBarMenuDefault.Text;

    public Color GetContentHighLightBackcolor()
        => CurrentThemeComponent.ColorPalette.ToolWindowBorder;

    public Color GetContentHighLightForecolor()
        => CurrentThemeComponent.ColorPalette.ToolWindowCaptionInactive.Text;

    public Color GetTitleBackcolor()
        => CurrentThemeComponent.ColorPalette.CommandBarToolbarDefault.Background;

    public Color GetTitleForecolor()
        => CurrentThemeComponent.ColorPalette.CommandBarToolbarDefault.OverflowButtonGlyph;

    public Color GetQuoteForecolor(decimal quote)
        => quote >= 0.0m ? Color.Crimson : Color.LimeGreen;
}
