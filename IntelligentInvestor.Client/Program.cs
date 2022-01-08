namespace IntelligentInvestor.Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using var launchForm = new LaunchForm(TimeSpan.FromSeconds(3));
            var result = launchForm.ShowDialog();

            Application.Run(new MainForm());
        }
    }
}