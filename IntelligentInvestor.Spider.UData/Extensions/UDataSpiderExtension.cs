using IntelligentInvestor.Spider.Options;
using Microsoft.Extensions.DependencyInjection;
using IntelligentInvestor.Spider.UData.Stocks;
using IntelligentInvestor.Spider.Stocks;

namespace IntelligentInvestor.Spider.UData.Extensions;

public static class UDataSpiderExtension
{
    public static IServiceCollection AddUDataSpider(this IServiceCollection services, SpiderOption options)
    {
        var httpClientConfiguration = new Action<HttpClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(options.BaseAddress);
            httpClient.DefaultRequestHeaders.Add("Application-Token", options.Token);
        });
        services.AddHttpClient<IStockSpider, UDataStockSpider>(httpClientConfiguration);
        return services.AddTransient<StockCodeMarketParser>();
    }
}
