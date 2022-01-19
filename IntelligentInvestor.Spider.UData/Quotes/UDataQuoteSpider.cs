using System.Drawing;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Spider.Quotes;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.UData.Quotes;

public class UDataQuoteSpider : IQuoteSpider
{
    private readonly ILogger<UDataQuoteSpider> logger;

    public UDataQuoteSpider(
        ILogger<UDataQuoteSpider> logger)
    {
        this.logger = logger;
    }

    public async Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency)
    {
        return default;
    }

    public async Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime? fromDate, DateTime? toDate)
    {
        return default;
    }

    public async Task<(Quote Quote, TradeStrand TradeStrand)> GetQuoteAsync(StockMarkets stockMarket, string stockCode)
    {
        return default;
    }
}
