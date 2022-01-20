using Bogus;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock.Quotes;

public class MockQuoteSpider : IQuoteSpider
{
    private readonly ILogger<MockQuoteSpider> logger;
    private readonly Faker<Quote> quoteFaker;
    private readonly Faker<TradeStrand> tradeStrandFaker;

    public MockQuoteSpider(
        ILogger<MockQuoteSpider> logger)
    {
        this.logger = logger;
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
    }

    public async Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime? fromDate, DateTime? toDate)
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

    public async Task<(Quote Quote, TradeStrand TradeStrand)> GetQuoteAsync(StockMarkets stockMarket, string stockCode)
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
}
