using IntelligentInvestor.Spider.Charts;
using IntelligentInvestor.Spider.Companys;
using IntelligentInvestor.Spider.Mock.Charts;
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
            .AddScoped<IChartSpider, MockChartSpider>()
            .AddScoped<ICompanySpider, MockCompanySpider>()
            .AddScoped<IStockSpider, MockStockSpider>()
            .AddScoped<IHotStockSpider, MockHotStockSpider>()
            .AddScoped<IQuoteSpider, MockQuoteSpider>();
}
