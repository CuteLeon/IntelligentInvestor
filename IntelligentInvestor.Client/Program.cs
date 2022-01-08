using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace IntelligentInvestor.Client
{
    internal static class Program
    {
        public static ProgramHost Host { get; } = new ProgramHost();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var launchForm = new LaunchForm(InitializeProgramHost);
            var result = launchForm.ShowDialog();
            if (result != DialogResult.OK)
                Application.Exit(new CancelEventArgs());

            var mainForm = Host.ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        static IEnumerable<string> InitializeProgramHost()
        {
            yield return "Initialize program host ...";

            foreach (var message in Host.InitializeServiceProvider())
                yield return message;
            Host.BuilderServiceProvider();

            yield return "Initialize successfully.";
        }

        static IEnumerable<string> InitializeServiceProvider(this ProgramHost host)
        {
            yield return "Initialize service provider ...";
            var services = host.Services;
            services.AddTransient<MainForm>();
            services.AddLogging(builder => builder.ClearProviders().AddNLog(new NLogProviderOptions()).SetMinimumLevel(LogLevel.Trace));
        }
    }
}