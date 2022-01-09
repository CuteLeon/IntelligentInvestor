using IntelligentInvestor.Client.Extensions;
using IntelligentInvestor.Infrastructure.Extensions;
using IntelligentInvestor.Intermediary.Extensions;
using IntelligentInvestor.Spider.Mock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLogger = NLog.Logger;
using WinApplication = System.Windows.Forms.Application;

namespace IntelligentInvestor.Client
{
    internal static class Program
    {
        public static ProgramHost Host { get; } = new ProgramHost();

        public static NLogger Logger { get; private set; }

        [STAThread]
        static void Main()
        {
            Logger = NLog.LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();
            WinApplication.EnableVisualStyles();
            WinApplication.SetCompatibleTextRenderingDefault(false);
            WinApplication.SetHighDpiMode(HighDpiMode.SystemAware);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            WinApplication.ThreadException += Application_ThreadException;
            WinApplication.ApplicationExit += Application_ApplicationExit;

            using var launchForm = new LaunchForm(InitializeProgramHost);
            var result = launchForm.ShowDialog();
            if (result != DialogResult.OK) return;

            var mainForm = Host.ServiceProvider.GetRequiredService<MainForm>();
            WinApplication.Run(mainForm);
        }

        static IEnumerable<string> InitializeProgramHost()
        {
            Logger.Debug("Initialize program host ...");
            yield return "Initialize program host ...";

            foreach (var message in Host.InitializeServiceProvider()
                .Concat(Host.InitializeConfigurationManager())
                .Concat(Host.InitializeStockSpider()))
                yield return message;

            Host.BuilderServiceProvider();
            Logger.Debug("Initialize successfully.");
            yield return "Initialize successfully.";
        }

        static IEnumerable<string> InitializeConfigurationManager(this ProgramHost host)
        {
            Logger.Debug("Initialize configuration manager ...");
            yield return "Initialize configuration manager ...";
            host.Configuration.AddJsonFile("AppSettings.json", true, true);
        }

        static IEnumerable<string> InitializeServiceProvider(this ProgramHost host)
        {
            Logger.Debug("Initialize service provider ...");
            yield return "Initialize service provider ...";
            var services = host.Services
                .AddIntelligentInvestorClient()
                .AddIntelligentInvestorIntermediary()
                .AddIntelligentInvestorDBContext(host.Configuration.GetConnectionString("IIDB"))
                .AddIntelligentInvestorInfrastructure();

            services.AddLogging(builder => builder.ClearProviders().AddNLog(new NLogProviderOptions()).SetMinimumLevel(LogLevel.Trace));
        }

        static IEnumerable<string> InitializeStockSpider(this ProgramHost host)
        {
            Logger.Debug("Initialize stock spider ...");
            yield return "Initialize stock spider ...";
            var services = host.Services.AddMockSpider();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Logger.Debug($"Application exits.");
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Error(e.Exception, "Applicarion error.");
            MessageBox.Show(
                $"Application error: \n{e.Exception.Message}",
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error(e.ExceptionObject as Exception, $"Domain error.");
            MessageBox.Show(
                $"Domain error: \n{(e.ExceptionObject as Exception)?.Message}",
                "Domain Error",
                MessageBoxButtons.OK,
                e.IsTerminating ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
        }
    }
}