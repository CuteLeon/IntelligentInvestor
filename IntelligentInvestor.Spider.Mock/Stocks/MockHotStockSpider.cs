using Bogus;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock.Stocks;

public class MockHotStockSpider : IHotStockSpider
{
    private readonly ILogger<MockHotStockSpider> logger;
    private readonly Faker<Stock> stockFaker;

    public MockHotStockSpider(
        ILogger<MockHotStockSpider> logger)
    {
        this.logger = logger;
        this.stockFaker = new Faker<Stock>()
            .RuleFor(x => x.StockMarket, faker => faker.PickRandom<StockMarkets>())
            .RuleFor(x => x.StockCode, faker => faker.Random.UInt(1, 999999).ToString())
            .RuleFor(x => x.StockName, faker => faker.Company.CompanyName())
            .RuleFor(x => x.IsSelected, faker => faker.Random.Bool());
    }

    public async Task<IEnumerable<Stock>> GetHotStocksAsync()
    {
        return this.stockFaker.GenerateBetween(10, 20).ToArray();
    }
}
