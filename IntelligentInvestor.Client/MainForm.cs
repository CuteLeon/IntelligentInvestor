using IntelligentInvestor.Client.DockForms;
using IntelligentInvestor.Client.DockForms.FloatWindows;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Themes;
using IntelligentInvestor.Spider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeifenLuo.WinFormsUI.Docking;
using WinApplication = System.Windows.Forms.Application;

namespace IntelligentInvestor.Client;

public partial class MainForm : Form
{
    private readonly ILogger<MainForm> logger;
    private readonly IUIThemeHandler themeHandler;
    private readonly IServiceProvider serviceProvider;
    private readonly IStockSpider stockSpider;

    public MainForm(
        ILogger<MainForm> logger,
        IUIThemeHandler themeHandler,
        IServiceScopeFactory serviceScopeFactory,
        IStockSpider stockSpider)
    {
        this.logger = logger;
        this.themeHandler = themeHandler;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockSpider = stockSpider;
        this.Icon = IntelligentInvestorResource.IntelligentInvestor;
        InitializeComponent();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        this.logger.LogDebug("Main form shown ...");
        WinApplication.DoEvents();

        /*
        if (File.Exists(ConfigHelper.GetLayoutFileName()))
        {
            try
            {
                this.LoadLayout();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Restore layout from file failed.");

                this.PredeterminedLayout();
            }
        }
        else
        {
         */
        this.PredeterminedLayout();
        /*
        }
         */
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        this.MainDockPanel.DocumentStyle = DocumentStyle.DockingMdi;
        this.MainDockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
        this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
        this.MainDockPanel.ShowDocumentIcon = true;

        this.ApplyTheme();
    }

    private void TestToolItem_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to test\n{ex.Message}");
        }
    }

    private void ThemeMenuItem_Click(object sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem menuItem || menuItem.Checked) return;
        UIThemes theme = (UIThemes)menuItem.Tag;
        // ThemeHelper.SaveNextTheme(theme);

        MessageBox.Show($"UI Theme will be changed to {theme} after next launch.", "UI Theme", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ApplyTheme()
    {
        this.LightThemeMenuItem.Tag = UIThemes.Light;
        this.BlueThemeMenuItem.Tag = UIThemes.Blue;
        this.DarkThemeMenuItem.Tag = UIThemes.Dark;

        if (this.themeHandler.CurrentTheme == UIThemes.Light)
            this.LightThemeMenuItem.Checked = true;
        else if (this.themeHandler.CurrentTheme == UIThemes.Dark)
            this.DarkThemeMenuItem.Checked = true;
        else if (this.themeHandler.CurrentTheme == UIThemes.Blue)
            this.BlueThemeMenuItem.Checked = true;

        this.MainDockPanel.Theme = this.themeHandler.CurrentThemeComponent;
        this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
        this.MainDockPanel.Theme.ApplyTo(this.MainTopMenuStrip);
        this.MainDockPanel.Theme.ApplyTo(this.MainToolStrip);
        this.MainDockPanel.Theme.ApplyTo(this.MainStatusStrip);
    }

    private void PredeterminedLayout()
    {
        var recentTradeForm = this.serviceProvider.GetRequiredService<RecentTradeForm>();
        recentTradeForm.Show(this.MainDockPanel);
        var currentQuotaForm = this.serviceProvider.GetRequiredService<CurrentQuotaForm>();
        currentQuotaForm.Show(recentTradeForm.Pane, recentTradeForm);

        var marketQuotaForm = this.serviceProvider.GetRequiredService<MarketQuotaForm>();
        marketQuotaForm.Show(recentTradeForm.Pane, DockAlignment.Bottom, 0.3);

        var searchStockForm = this.serviceProvider.GetRequiredService<SearchStockDockForm>();
        searchStockForm.Show(this.MainDockPanel);
        var hotStockForm = this.serviceProvider.GetRequiredService<HotStockDockForm>();
        hotStockForm.Show(searchStockForm.Pane, DockAlignment.Top, 0.56);
        var selfSelectForm = this.serviceProvider.GetRequiredService<SelfSelectStockForm>();
        selfSelectForm.Show(hotStockForm.Pane, hotStockForm);
    }

    private void SearchToolButton_Click(object sender, EventArgs e)
    {
        SearchStockDockForm dockForm = this.serviceProvider.GetRequiredService<SearchStockDockForm>();
        if (dockForm == null)
        {
            return;
        }

        dockForm.Show(this.MainDockPanel);
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        this.OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, false));
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.UserClosing) return;
        if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) return;
        e.Cancel = true;
    }

    public void RegisterDockFormToViewMenu<TDockForm>(string text, Image image)
        where TDockForm : DockFormBase
    {
        var menuItem = this.ViewMenuItem.DropDownItems.Add(text, image);
        menuItem.Tag = typeof(TDockForm);
        menuItem.Click += this.ViewsMenuItem_Click;
    }

    private void ViewsMenuItem_Click(object sender, EventArgs e)
    {
        Type viewType = (sender as ToolStripItem)?.Tag as Type;
        if (!(this.serviceProvider.GetRequiredService(viewType!) is DockFormBase dockForm))
        {
            throw new NullReferenceException();
        }

        if (dockForm.IsHidden ||
            !dockForm.Visible)
        {
            dockForm.Show(this.MainDockPanel);
        }
        else
        {
            dockForm.Activate();
        }
    }

    private void SaveLayoutMenuItem_Click(object sender, EventArgs e)
    {
        this.SaveLayoute();

        MessageBox.Show($"Save layout successfully.", "Save Layout", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void LoadLayout()
    {
        // this.MainDockPanel.LoadFromXml(ConfigHelper.GetLayoutFileName(), this.GetDockContent);
    }

    private void SaveLayoute()
    {
        // this.MainDockPanel.SaveAsXml(ConfigHelper.GetLayoutFileName());
    }

    private DockFormBase GetDockContent(string persist)
    {
        try
        {
            string[] persists = persist.Split(new[] { '@' }, 2);
            Type type = this.GetType().Assembly.GetType(persists[0]);
            if (!(this.serviceProvider.GetRequiredService(type) is DockFormBase dockForm))
            {
                return default;
            }

            if (persists.Length > 1)
            {
                dockForm.PersistValue = persists[1];
            }

            return dockForm;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, $"Restore form instance from {persist} failed.");
            return default;
        }
    }
}
