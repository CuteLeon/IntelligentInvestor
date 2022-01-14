using IntelligentInvestor.Spider.Mock.Quotes;
using IntelligentInvestor.Spider.Mock.Stocks;
using IntelligentInvestor.Spider.Quotes;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Spider.Mock;

public static class MockSpiderExtension
{
    public static IServiceCollection AddMockSpider(this IServiceCollection services)
        => services
            .AddScoped<IStockSpider, MockStockSpider>()
            .AddScoped<IQuoteSpider, MockQuoteSpider>();
}
