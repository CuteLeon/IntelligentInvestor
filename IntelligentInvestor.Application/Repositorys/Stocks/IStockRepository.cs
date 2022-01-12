using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Application.Repositorys.Stocks;

public interface IStockRepository : IRepositoryBase<Stock>
{
    Stock AddOrUpdateStock(Stock stock);

    Task<Stock> AddOrUpdateStockAsync(Stock stock);

    Stock? GetStock(StockMarkets stockMarket, string stockCode);

    Task<Stock?> GetStockAsync(StockMarkets stockMarket, string stockCode);

    Task<IEnumerable<Stock?>> SearchStocksAsync(string keyword, bool? isSelected = null);
}
