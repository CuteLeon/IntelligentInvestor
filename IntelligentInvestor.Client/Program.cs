using IntelligentInvestor.Client.Extensions;
using IntelligentInvestor.Domain.Intermediary.Stocks;
using IntelligentInvestor.Domain.Intermediary.Themes;
using IntelligentInvestor.Infrastructure.Extensions;
using IntelligentInvestor.Intermediary.Extensions;
using IntelligentInvestor.Spider.Mock;
using Microsoft.EntityFrameworkCore;
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

            using (var launchForm = new LaunchForm(InitializeProgramHost))
            {
                var result = launchForm.ShowDialog();
                if (result != DialogResult.OK) return;
            }

            var mainForm = Host.ServiceProvider.GetRequiredService<MainForm>();
            WinApplication.Run(mainForm);
        }

        static async IAsyncEnumerable<string> InitializeProgramHost()
        {
            Logger.Debug("Initialize program host ...");
            yield return "Initialize program host ...";

            foreach (var message in Host.InitializeConfigurationManager()
                .Concat(Host.InitializeServiceProvider())
                .Concat(Host.InitializeStockSpider())
                .Concat(Host.InitializeIntermediary())
                .Concat(Host.BuilderServiceProvider()))
                yield return message;

            await foreach (var message in Host.InitializeDatabase())
                yield return message;

            Logger.Debug("Initialize successfully.");
            yield return "Initialize successfully.";
        }

        static IEnumerable<string> InitializeConfigurationManager(this ProgramHost host)
        {
            Logger.Debug("Initialize configuration manager ...");
            yield return "Initialize configuration manager ...";
            host.Configuration.AddJsonFile("AppSettings.json", true, true);
            host.Services.AddSingleton(host.Configuration);
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

        static async IAsyncEnumerable<string> InitializeDatabase(this ProgramHost host)
        {
            Logger.Debug("Initialize database ...");
            yield return "Initialize database ...";

            using var scope = host.ServiceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<DbContext>();

            try
            {
                Logger.Debug($"Ensure database created...");
                await dbContext.Database.EnsureCreatedAsync();
                Logger.Debug($"Check database pending migrations...");
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    Logger.Info($"Pending database migration should be combined: \n\t{string.Join(",", pendingMigrations)}");
                    await dbContext.Database.MigrateAsync();
                }
                Logger.Debug($"Database check finished.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Database check failed.");
            }
        }

        static IEnumerable<string> InitializeStockSpider(this ProgramHost host)
        {
            Logger.Debug("Initialize stock spider ...");
            yield return "Initialize stock spider ...";
            var services = host.Services.AddMockSpider();
        }

        static IEnumerable<string> InitializeIntermediary(this ProgramHost host)
        {
            Logger.Debug("Initialize intermediary ...");
            yield return "Initialize intermediary ...";
            host.Services
                .AddIntermediaryEvent<StockEvent>()
                .AddIntermediaryEvent<ThemeEvent>();
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