using IntelligentInvestor.Client.DockForms;
using IntelligentInvestor.Client.Themes;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Client.Extensions;

public static class IntelligentInvestorClientExtension
{
    public static IServiceCollection AddIntelligentInvestorClient(this IServiceCollection services)
    {
        return services
                .AddSingleton<IUIThemeHandler, UIThemeHandler>()
                .AddSingleton<MainForm>()
                .AddSingleton<TradeHistoryForm>()
                .AddSingleton<MarketIndexForm>()
                .AddSingleton<TradeQuoteForm>()
                .AddSingleton<HotStockDockForm>()
                .AddSingleton<SearchStockDockForm>()
                .AddSingleton<SelectedStockForm>()
                .AddTransient<ChartDocumentForm>()
                .AddTransient<QuoteHistoryDocumentForm>()
                .AddTransient<QuoteRepositoryDocumentForm>();
    }
}
