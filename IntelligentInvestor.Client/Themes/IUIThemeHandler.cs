using WeifenLuo.WinFormsUI.Docking;

namespace IntelligentInvestor.Client.Themes;

public interface IUIThemeHandler
{
    public UIThemes CurrentTheme { get; set; }

    public ThemeBase CurrentThemeComponent { get; }

    public ThemeBase GetTheme(UIThemes theme);

    public Color GetContainerBackcolor();

    public Color GetContentForecolor();

    public Color GetContentHighLightBackcolor();

    public Color GetContentHighLightForecolor();

    public Color GetTitleBackcolor();

    public Color GetTitleForecolor();

    public Color GetQuotaForecolor(decimal quota);
}
