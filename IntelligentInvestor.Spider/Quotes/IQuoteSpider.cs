using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Spider.Quotes;

public interface IQuoteSpider
{
    Task<(Quote Quote, TradeStrand TradeStrand)> GetQuoteAsync(StockMarkets stockMarket, string stockCode);

    Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime? fromDate, DateTime? toDate);
}
