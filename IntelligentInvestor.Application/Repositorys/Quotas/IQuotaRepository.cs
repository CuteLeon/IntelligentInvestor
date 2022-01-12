using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Application.Repositorys.Quotas;

public interface IQuotaRepository : IRepositoryBase<Quota>
{
    Task<IEnumerable<Quota>> GetStockQuotasAsync(StockMarkets stockMarket, string stockCode, QuotaFrequencys? quotaFrequency = null, DateTime? fromTime = null, DateTime? toTime = null);
}
