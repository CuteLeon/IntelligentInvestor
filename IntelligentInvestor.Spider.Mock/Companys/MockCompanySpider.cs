using Bogus;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Companys;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock.Companys;

public class MockCompanySpider : ICompanySpider
{
    private readonly ILogger<MockCompanySpider> logger;
    private readonly Faker<Company> companyFaker;

    public MockCompanySpider(
        ILogger<MockCompanySpider> logger)
    {
        this.logger = logger;
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
    }

    public async Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode)
    {
        var result = this.companyFaker.Generate();
        result.StockMarket = stockMarket;
        result.StockCode = stockCode;
        return result;
    }
}
