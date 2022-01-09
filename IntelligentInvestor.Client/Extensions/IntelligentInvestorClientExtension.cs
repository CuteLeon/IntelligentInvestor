using IntelligentInvestor.Client.DockForms;
using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Client.Extensions;

public static class IntelligentInvestorClientExtension
{
    public static IServiceCollection AddIntelligentInvestorClient(this IServiceCollection services)
        => services
            .AddSingleton<IUIThemeHandler, UIThemeHandler>()
            .AddSingleton<MainForm>()
            .AddSingleton<RecentTradeForm>()
            .AddSingleton<MarketQuotaForm>()
            .AddSingleton<CurrentQuotaForm>()
            .AddSingleton<HotStockDockForm>()
            .AddSingleton<SearchStockDockForm>()
            .AddSingleton<SelfSelectStockForm>()
            .AddTransient<ChartDocumentForm>()
            .AddTransient<RecentQuotaDocumentForm>()
            .AddTransient<QuotaRepositoryDocumentForm>();
}
