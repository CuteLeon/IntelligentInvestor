namespace IntelligentInvestor.Client
{
    public partial class LaunchForm : Form
    {
        private readonly TimeSpan waitTimeSpan;

        public LaunchForm(TimeSpan waitTimeSpan)
        {
            this.Icon = IntelligentInvestorResource.IntelligentInvestor;
            this.InitializeComponent();
            this.waitTimeSpan = waitTimeSpan;
        }

        private void LaunchForm_Shown(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(waitTimeSpan);
                this.DialogResult = DialogResult.OK;
            });
        }
    }
}