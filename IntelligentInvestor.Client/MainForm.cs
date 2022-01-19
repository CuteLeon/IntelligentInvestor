using IntelligentInvestor.Client.DockForms;
using IntelligentInvestor.Client.DockForms.FloatWindows;
using IntelligentInvestor.Client.Themes;
using IntelligentInvestor.Domain.Options;
using IntelligentInvestor.Domain.Themes;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeifenLuo.WinFormsUI.Docking;
using WinApplication = System.Windows.Forms.Application;

namespace IntelligentInvestor.Client;


// Test cc
public partial class MainForm : Form
{
    private readonly ILogger<MainForm> logger;
    private readonly IUIThemeHandler themeHandler;
    private readonly IGenericOptionRepository genericOptionRepository;
    private readonly IServiceProvider serviceProvider;
    private readonly IStockSpider stockSpider;
    private const string DockLayoutFileName = "IntelligentInvestor.Layout.xml";

    public MainForm(
        ILogger<MainForm> logger,
        IUIThemeHandler themeHandler,
        IServiceScopeFactory serviceScopeFactory,
        IGenericOptionRepository genericOptionRepository,
        IStockSpider stockSpider)
    {
        this.logger = logger;
        this.themeHandler = themeHandler;
        this.genericOptionRepository = genericOptionRepository;
        this.serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        this.stockSpider = stockSpider;
        this.Icon = IntelligentInvestorResource.IntelligentInvestor;
        InitializeComponent();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        this.logger.LogDebug("Main form shown ...");
        WinApplication.DoEvents();

        this.InitializeLayout();
        this.InitializeViewMenu();
        WinApplication.DoEvents();
    }

    private void InitializeViewMenu()
    {
        this.RegisterDockFormToViewMenu<TradeHistoryForm>();
        this.RegisterDockFormToViewMenu<MarketIndexForm>();
        this.RegisterDockFormToViewMenu<TradeQuoteForm>();
        this.RegisterDockFormToViewMenu<HotStockDockForm>();
        this.RegisterDockFormToViewMenu<SearchStockDockForm>();
        this.RegisterDockFormToViewMenu<SelectedStockForm>();
    }

    public void RegisterDockFormToViewMenu<TDockForm>()
        where TDockForm : DockFormBase
    {
        var instance = this.serviceProvider.GetRequiredService<TDockForm>();
        this.logger.LogDebug($"Register dock form into view menu: {instance.Text} ...");
        var menuItem = this.ViewMenuItem.DropDownItems.Add(instance.Text, Bitmap.FromHicon(instance.Icon.Handle));
        menuItem.Tag = typeof(TDockForm);
        menuItem.Click += this.ViewsMenuItem_Click;
    }

    private void InitializeLayout()
    {
        if (File.Exists(DockLayoutFileName))
        {
            try
            {
                this.LoadLayout();
                return;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Restore layout from file failed.");
            }
        }

        this.PredeterminedLayout();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        this.IsMdiContainer = true;
        this.MainDockPanel.DocumentStyle = DocumentStyle.DockingMdi;
        this.MainDockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
        this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
        this.MainDockPanel.ShowDocumentIcon = true;

        await this.ApplyTheme();
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

    private async void ThemeMenuItem_Click(object sender, EventArgs e)
    {
        if (sender is not ToolStripMenuItem menuItem || menuItem.Checked) return;
        UIThemes theme = (UIThemes)menuItem.Tag;
        this.logger.LogDebug($"Set theme to {theme} ...");
        await this.genericOptionRepository.AddOrUpdateGenericOptionAsync(new GenericOption()
        {
            Category = "UI",
            OptionName = "Theme",
            OwnerLevel = "Client",
            OptionValue = theme.ToString(),
        });

        MessageBox.Show($"UI Theme will be changed to {theme} after next launch.", "UI Theme", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public async Task ApplyTheme()
    {
        this.LightThemeMenuItem.Tag = UIThemes.Light;
        this.BlueThemeMenuItem.Tag = UIThemes.Blue;
        this.DarkThemeMenuItem.Tag = UIThemes.Dark;

        var themeName = await this.genericOptionRepository.GetGenericOptionAsync("Theme", "Client", "UI");
        if (!Enum.TryParse(themeName?.OptionValue, out UIThemes theme)) theme = UIThemes.Dark;
        this.themeHandler.SetTheme(theme);
        if (theme == UIThemes.Light)
            this.LightThemeMenuItem.Checked = true;
        else if (theme == UIThemes.Dark)
            this.DarkThemeMenuItem.Checked = true;
        else if (theme == UIThemes.Blue)
            this.BlueThemeMenuItem.Checked = true;

        this.MainDockPanel.Theme = this.themeHandler.CurrentThemeComponent;
        this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
        this.MainDockPanel.Theme.ApplyTo(this.MainTopMenuStrip);
        this.MainDockPanel.Theme.ApplyTo(this.MainToolStrip);
        this.MainDockPanel.Theme.ApplyTo(this.MainStatusStrip);
    }

    private void PredeterminedLayout()
    {
        this.logger.LogDebug("Load predetermined layout ...");
        var tradeHistoryForm = this.serviceProvider.GetRequiredService<TradeHistoryForm>();
        tradeHistoryForm.Show(this.MainDockPanel);
        var tradeQuoteForm = this.serviceProvider.GetRequiredService<TradeQuoteForm>();
        tradeQuoteForm.Show(tradeHistoryForm.Pane, tradeHistoryForm);

        var marketIndexForm = this.serviceProvider.GetRequiredService<MarketIndexForm>();
        marketIndexForm.Show(tradeHistoryForm.Pane, DockAlignment.Bottom, 0.3);

        var searchStockForm = this.serviceProvider.GetRequiredService<SearchStockDockForm>();
        searchStockForm.Show(this.MainDockPanel);
        var hotStockForm = this.serviceProvider.GetRequiredService<HotStockDockForm>();
        hotStockForm.Show(searchStockForm.Pane, DockAlignment.Top, 0.56);
        var selectedStockForm = this.serviceProvider.GetRequiredService<SelectedStockForm>();
        selectedStockForm.Show(hotStockForm.Pane, hotStockForm);
    }

    private void SearchToolButton_Click(object sender, EventArgs e)
    {
        SearchStockDockForm dockForm = this.serviceProvider.GetRequiredService<SearchStockDockForm>();
        if (dockForm == null) return;

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

    private void ViewsMenuItem_Click(object sender, EventArgs e)
    {
        Type viewType = (sender as ToolStripItem)?.Tag as Type;
        this.logger.LogDebug($"Launch {viewType.FullName} view ...");
        if (!(this.serviceProvider.GetRequiredService(viewType!) is DockFormBase dockForm))
        {
            throw new NullReferenceException();
        }

        if (dockForm.IsHidden || !dockForm.Visible)
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
        this.logger.LogDebug($"Load layout from {DockLayoutFileName} ...");
        this.MainDockPanel.LoadFromXml(DockLayoutFileName, this.GetDockContent);
    }

    private void SaveLayoute()
    {
        this.logger.LogDebug($"Save layout to {DockLayoutFileName} ...");
        this.MainDockPanel.SaveAsXml(DockLayoutFileName);
    }

    private DockFormBase GetDockContent(string persist)
    {
        try
        {
            string[] persists = persist.Split(new[] { '@' }, 2);
            Type type = this.GetType().Assembly.GetType(persists[0]);
            this.logger.LogDebug($"Restore dock form {type.FullName} ...");

            if (this.serviceProvider.GetRequiredService(type) is not DockFormBase dockForm)
            {
                return default;
            }

            if (persists.Length > 1)
            {
                this.logger.LogDebug($"Dock form persist value => {persists[1]}");
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
