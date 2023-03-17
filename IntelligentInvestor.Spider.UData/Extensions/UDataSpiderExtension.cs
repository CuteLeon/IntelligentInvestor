using IntelligentInvestor.Spider.Options;
using IntelligentInvestor.Spider.Quotes;
using IntelligentInvestor.Spider.Stocks;
using IntelligentInvestor.Spider.UData.Quotes;
using IntelligentInvestor.Spider.UData.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Spider.UData.Extensions;

[Obsolete("Token expired")]
public static class UDataSpiderExtension
{
    public static IServiceCollection AddUDataSpider(this IServiceCollection services, SpiderOption options)
    {
        var httpClientConfiguration = new Action<HttpClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(options.BaseAddress);
            httpClient.DefaultRequestHeaders.Add("Application-Token", options.Token);
        });
        _ = services.AddHttpClient<IStockSpider, UDataStockSpider>(httpClientConfiguration);
        _ = services.AddHttpClient<IQuoteSpider, UDataQuoteSpider>(httpClientConfiguration);
        _ = services.AddHttpClient<IHotStockSpider, UDataHotStockSpider>(httpClientConfiguration);
        return services.AddTransient<StockCodeMarketParser>();
    }
}
