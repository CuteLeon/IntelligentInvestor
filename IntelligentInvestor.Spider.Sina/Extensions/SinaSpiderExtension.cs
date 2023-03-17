using IntelligentInvestor.Spider.Charts;
using IntelligentInvestor.Spider.Options;
using IntelligentInvestor.Spider.Sina.Charts;
using IntelligentInvestor.Spider.Sina.Stocks;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Spider.Sina.Extensions;

public static class SinaSpiderExtension
{
    public static IServiceCollection AddSinaSpider(this IServiceCollection services, SpiderOption options)
    {
        _ = services.AddHttpClient<IChartSpider, SinaChartSpider>();
        _ = services.AddHttpClient<IStockSpider, SinaStockSpider>();
        return services;
    }
}
