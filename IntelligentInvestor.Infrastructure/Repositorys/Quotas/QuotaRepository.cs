using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Infrastructure.Repositorys.Quotas;

public class QuotaRepository : RepositoryBase<Quota>, IQuotaRepository
{
    public QuotaRepository(
        ILogger<RepositoryBase<Quota>> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }

    public async Task<IEnumerable<Quota>> GetStockQuotasAsync(
        StockMarkets stockMarket,
        string stockCode,
        QuotaFrequencys? quotaFrequency = null,
        DateTime? fromTime = null,
        DateTime? toTime = null)
    {
        var query = this.Set().Where(x => x.StockMarket == stockMarket && x.StockCode == stockCode);
        if (quotaFrequency.HasValue) query = query.Where(x => x.Frequency == quotaFrequency);
        if (fromTime.HasValue) query = query.Where(x => x.QuotaTime >= fromTime.Value);
        if (toTime.HasValue) query = query.Where(x => x.QuotaTime <= toTime.Value);

        query = query.OrderBy(x => x.QuotaTime);
        return await query.ToListAsync();
    }
}
