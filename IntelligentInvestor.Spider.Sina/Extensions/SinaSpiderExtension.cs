using IntelligentInvestor.Spider.Options;
using Microsoft.Extensions.DependencyInjection;
using IntelligentInvestor.Spider.Mock.Charts;
using IntelligentInvestor.Spider.Charts;

namespace IntelligentInvestor.Spider.Sina.Extensions;

public static class SinaSpiderExtension
{
    public static IServiceCollection AddSinaSpider(this IServiceCollection services, SpiderOption options)
    {
        services.AddHttpClient<IChartSpider, SinaChartSpider>();
        return services;
    }
}
