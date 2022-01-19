using IntelligentInvestor.Spider.Options;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Spider.UData.Extensions;

public static class UDataSpiderExtension
{
    public static IServiceCollection AddUDataSpider(this IServiceCollection services, SpiderOption options)
        => services;
}
