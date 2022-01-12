using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Application.Repositorys.Stocks;

public interface IStockRepository : IRepositoryBase<Stock>
{
    Stock? GetStock(StockMarkets stockMarket, string stockCode);

    Task<Stock?> GetStockAsync(StockMarkets stockMarket, string stockCode);
}
