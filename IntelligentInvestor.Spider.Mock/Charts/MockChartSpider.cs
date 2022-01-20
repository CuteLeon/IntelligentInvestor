using System.Drawing;
using Bogus;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Charts;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock.Charts;

public class MockChartSpider : IChartSpider
{
    private readonly Faker chartsFaker;
    private readonly Bitmap[] bitmaps;
    private readonly ILogger<MockChartSpider> logger;

    public MockChartSpider(
        ILogger<MockChartSpider> logger)
    {
        this.logger = logger;
        this.bitmaps = new[]
        {
            SpiderMockResource.Chart_1,
            SpiderMockResource.Chart_2,
            SpiderMockResource.Chart_3,
        };
        this.chartsFaker = new Faker();
    }

    public async Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency)
    {
        return this.chartsFaker.PickRandom(bitmaps);
    }
}
