using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Application.Repositorys.Quotes;

public interface IQuoteRepository : IRepositoryBase<Quote>
{
    Task<IEnumerable<Quote>> GetStockQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency = QuoteFrequencys.NotSpecified, DateTime? fromTime = null, DateTime? toTime = null);
}
