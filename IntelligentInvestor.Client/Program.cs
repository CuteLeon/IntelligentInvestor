namespace IntelligentInvestor.Client
{
    internal static class Program
    {
        public static ProgramHost ProgramHost { get; } = new ProgramHost();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var launchForm = new LaunchForm(InitializeProgramHost);
            var result = launchForm.ShowDialog();

            Application.Run(new MainForm());
        }

        static IEnumerable<string> InitializeProgramHost()
        {
            yield return "Initialize program host ...";
        }
    }
}