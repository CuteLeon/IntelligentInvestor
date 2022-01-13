using System.Drawing;
using Bogus;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock;

public class MockStockSpider : IStockSpider
{
    private readonly ILogger<MockStockSpider> logger;
    private readonly Faker<Stock> stockFaker;
    private readonly Faker<Quote> quoteFaker;
    private readonly Faker<Company> companyFaker;
    private readonly Faker<TradeStrand> tradeStrandFaker;
    private readonly Faker chartsFaker;
    private readonly Bitmap[] bitmaps;

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
        this.quoteFaker = new Faker<Quote>()
            .RuleFor(x => x.StockMarket, faker => faker.PickRandom<StockMarkets>())
            .RuleFor(x => x.StockCode, faker => faker.Random.UInt(1, 999999).ToString())
            .RuleFor(x => x.Amount, faker => faker.Finance.Amount())
            .RuleFor(x => x.FluctuatingRange, faker => faker.Finance.Amount(-10, 10))
            .RuleFor(x => x.ClosingPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.ClosingPriceYesterday, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.CurrentPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.FluctuatingRate, faker => faker.Finance.Amount(-1, 1))
            .RuleFor(x => x.Frequency, faker => faker.PickRandom<QuoteFrequencys>())
            .RuleFor(x => x.HighestPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.LowestPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.OpenningPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.QuoteTime, faker => DateTime.Now)
            .RuleFor(x => x.Volume, faker => faker.Finance.Random.Int(100, 100000));
        this.tradeStrandFaker = new Faker<TradeStrand>()
            .RuleFor(x => x.AuctionPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BiddingPrice, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyPrice1, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyPrice2, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyPrice3, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyPrice4, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyPrice5, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.BuyStrand1, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.BuyStrand2, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.BuyStrand3, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.BuyStrand4, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.BuyStrand5, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.SellPrice1, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.SellPrice2, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.SellPrice3, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.SellPrice4, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.SellPrice5, faker => faker.Finance.Amount(10, 100))
            .RuleFor(x => x.SellStrand1, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.SellStrand2, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.SellStrand3, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.SellStrand4, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.SellStrand5, faker => faker.Finance.Random.Int(100, 100000))
            .RuleFor(x => x.QuoteTime, faker => DateTime.Now);
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

    public async Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode)
    {
        var result = this.companyFaker.Generate();
        result.StockMarket = stockMarket;
        result.StockCode = stockCode;
        return result;
    }

    public async Task<IEnumerable<Stock>> GetHotStocksAsync()
    {
        return this.stockFaker.GenerateBetween(10, 20).ToArray();
    }

    public async Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime fromDate, DateTime toDate)
    {
        var result = this.quoteFaker.GenerateBetween(100, 300).ToList();
        result.ForEach(x =>
        {
            x.Frequency = quoteFrequency;
            x.StockMarket = stockMarket;
            x.StockCode = stockCode;
        });
        return result;
    }

    public async Task<(Quote Quote, TradeStrand TradeStrand)> GetStockQuoteAsync(StockMarkets stockMarket, string stockCode)
    {
        var quote = this.quoteFaker.Generate();
        var tradeStrand = this.tradeStrandFaker.Generate();
        quote.Frequency = QuoteFrequencys.Trade;
        quote.StockMarket = stockMarket;
        quote.StockCode = stockCode;
        tradeStrand.StockMarket = stockMarket;
        tradeStrand.StockCode = stockCode;
        return (quote, tradeStrand);
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        var result = this.stockFaker.GenerateBetween(5, 10).ToArray();
        return result;
    }
}
