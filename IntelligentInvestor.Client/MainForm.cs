using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Client
{
    public partial class MainForm : Form
    {
        private readonly ILogger<MainForm> logger;

        public MainForm(ILogger<MainForm> logger)
        {
            this.logger = logger;
            this.Icon = IntelligentInvestorResource.IntelligentInvestor;
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.logger.LogDebug("Main form shown ...");
        }
    }
}
