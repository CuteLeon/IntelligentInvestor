using System.Drawing;
using Bogus;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock;

public class MockStockSpider : IStockSpider
{
    private readonly ILogger<MockStockSpider> logger;
    private readonly Faker<Stock> stockFaker;
    private readonly Faker<Quota> quotaFaker;
    private readonly Faker<Company> companyFaker;

    public MockStockSpider(
        ILogger<MockStockSpider> logger)
    {
        this.logger = logger;
        this.stockFaker = new Faker<Stock>()
            .RuleFor(x => x.StockMarket, faker => faker.PickRandom<StockMarkets>())
            .RuleFor(x => x.StockCode, faker => faker.Random.UInt(1, 999999).ToString())
            .RuleFor(x => x.StockName, faker => faker.Company.CompanyName())
            .RuleFor(x => x.IsSelected, faker => faker.Random.Bool());
        this.companyFaker = new Faker<Company>()
            .RuleFor(x => x.StockMarket, faker => faker.PickRandom<StockMarkets>())
            .RuleFor(x => x.StockCode, faker => faker.Random.UInt(1, 999999).ToString())
            .RuleFor(x => x.Description, faker => faker.Lorem.Text())
            .RuleFor(x => x.Industry, faker => faker.Lorem.Text())
            .RuleFor(x => x.Location, faker => faker.Address.FullAddress())
            .RuleFor(x => x.Name, faker => faker.Company.CompanyName())
            .RuleFor(x => x.Rank, faker => faker.Lorem.Letter().ToUpper())
            .RuleFor(x => x.Status, faker => faker.PickRandom<CompanyStatuses>())
            .RuleFor(x => x.Summary, faker => faker.Lorem.Text())
            .RuleFor(x => x.Vote, faker => faker.Random.Int(0, 5));
        this.quotaFaker = new Faker<Quota>()
            .RuleFor(x => x.StockMarket, faker => faker.PickRandom<StockMarkets>())
            .RuleFor(x => x.StockCode, faker => faker.Random.UInt(1, 999999).ToString())
            .RuleFor(x => x.Amount, faker => faker.Finance.Amount())
            .RuleFor(x => x.FluctuatingRange, faker => faker.Finance.Amount(-10, 10))
            .RuleFor(x => x.ClosingPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.ClosingPriceYesterday, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.CurrentPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.FluctuatingRate, faker => faker.Finance.Amount(-1, 1))
            .RuleFor(x => x.Frequency, faker => faker.PickRandom<QuotaFrequencys>())
            .RuleFor(x => x.HighestPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.LowestPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.OpenningPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.QuotaTime, DateTime.Now)
            .RuleFor(x => x.Volume, faker => faker.Finance.Random.Int(100, 100000));
    }

    public async Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuotaFrequencys quotaFrequency)
    {
        return default;
    }

    public async Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode)
    {
        return this.companyFaker.Generate();
    }

    public async Task<IEnumerable<Stock>> GetHotStocksAsync()
    {
        return this.stockFaker.GenerateForever().Take(10).ToArray();
    }

    public async Task<IEnumerable<Quota>> GetQuotasAsync(StockMarkets stockMarket, string stockCode, QuotaFrequencys quotaFrequency, DateTime fromDate, DateTime toDate)
    {
        return this.quotaFaker.GenerateForever().Take(100).ToArray();
    }

    public async Task<(Stock Stock, Quota Quota)> GetStockQuotaAsync(StockMarkets stockMarket, string stockCode)
    {
        return (this.stockFaker.Generate(), this.quotaFaker.Generate());
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        return this.stockFaker.GenerateForever().Take(5).ToArray();
    }
}
