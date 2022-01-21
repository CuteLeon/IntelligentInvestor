using IntelligentInvestor.Client.Interfaces;
using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.Logging;
using WeifenLuo.WinFormsUI.Docking;

namespace IntelligentInvestor.Client.DockForms;

public partial class DockFormBase : DockContent, IThemeAppliable
{
    protected readonly ILogger<DockFormBase> logger;
    protected readonly IUIThemeHandler themeHandler;

    public DockFormBase() : base() { }

    public DockFormBase(
        ILogger<DockFormBase> logger,
        IUIThemeHandler themeHandler)
        : this()
    {
        this.InitializeComponent();
        this.logger = logger;
        this.themeHandler = themeHandler;
    }

    public virtual string PersistValue { get; set; } = string.Empty;

    public override string Text
    {
        get => base.Text;

        set
        {
            base.Text = value;
            this.TabText = value;
        }
    }

    private void DockFormBase_Load(object sender, EventArgs e)
    {
        if (this.DesignMode)
        {
            return;
        }

        this.ApplyTheme();
    }

    public virtual void ApplyTheme()
    {
        if (this.themeHandler.CurrentThemeComponent == null)
        {
            return;
        }

        foreach (var toolStrip in this.Controls.OfType<ToolStrip>())
        {
            this.themeHandler.CurrentThemeComponent.ApplyTo(toolStrip);
        }

        this.BackColor = this.themeHandler.GetContainerBackcolor();
    }

    public virtual IEnumerable<string> Initialize()
    {
        yield break;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (this.HideOnClose && e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        base.OnFormClosing(e);
    }

    protected override string GetPersistString()
    {
        string persistValue = this.PersistValue;
        return $"{base.GetPersistString()}{(string.IsNullOrEmpty(persistValue) ? string.Empty : $"@{persistValue}")}";
    }
}
