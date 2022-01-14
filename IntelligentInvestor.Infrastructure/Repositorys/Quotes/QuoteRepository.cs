using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Quotes;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Infrastructure.Repositorys.Quotes;

public class QuoteRepository : RepositoryBase<Quote>, IQuoteRepository
{
    public QuoteRepository(
        ILogger<QuoteRepository> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }

    public async Task<IEnumerable<Quote>> GetQuotesAsync(
        StockMarkets stockMarket,
        string stockCode,
        QuoteFrequencys quoteFrequency = QuoteFrequencys.NotSpecified,
        DateTime? fromTime = null,
        DateTime? toTime = null)
    {
        var query = this.Set().Where(x => x.StockMarket == stockMarket && x.StockCode == stockCode);
        if (quoteFrequency != QuoteFrequencys.NotSpecified) query = query.Where(x => x.Frequency == quoteFrequency);
        if (fromTime.HasValue) query = query.Where(x => x.QuoteTime >= fromTime.Value);
        if (toTime.HasValue) query = query.Where(x => x.QuoteTime <= toTime.Value);

        query = query.OrderBy(x => x.QuoteTime);
        return await query.ToListAsync();
    }
}
