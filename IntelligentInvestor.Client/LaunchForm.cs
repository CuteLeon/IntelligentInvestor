using WinApplication = System.Windows.Forms.Application;

namespace IntelligentInvestor.Client;

public partial class LaunchForm : Form
{
    public Func<IAsyncEnumerable<string>> LaunchMethod { get; init; }

    public LaunchForm(Func<IAsyncEnumerable<string>> launchMethod)
    {
        this.LaunchMethod = launchMethod;
        this.Icon = IntelligentInvestorResource.IntelligentInvestor;
        this.InitializeComponent();
    }

    private async void LaunchForm_Shown(object sender, EventArgs e)
    {
        var result = false;
        WinApplication.DoEvents();

        _ = await Task.WhenAll(
            Task.Delay(3000),
            Task.Run(async () =>
            {
                try
                {
                    await foreach (var message in this.LaunchMethod.Invoke())
                    {
                        this.ShowMessage(message);
                    }
                    result = true;
                }
                catch (Exception ex)
                {
                    this.ShowMessage(ex.Message);
                    result = false;
                }
            }))
            .ContinueWith(
                task => this.DialogResult = result ? DialogResult.OK : DialogResult.Abort,
                TaskContinuationOptions.ExecuteSynchronously);
    }

    private void ShowMessage(string message)
    {
        this.Invoke(() =>
    {
        this.Invoke(() =>
        {
            this.MessageLabel.Text = message;
            WinApplication.DoEvents();
        });
    });
    }
}
