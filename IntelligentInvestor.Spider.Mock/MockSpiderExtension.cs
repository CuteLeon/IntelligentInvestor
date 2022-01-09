using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Spider.Mock;

public static class MockSpiderExtension
{
    public static IServiceCollection AddMockSpider(this IServiceCollection services)
        => services.AddScoped<IStockSpider, MockStockSpider>();
}
