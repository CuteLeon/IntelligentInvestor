using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Infrastructure.Repositorys.Stocks;

public class StockRepository : RepositoryBase<Stock>, IStockRepository
{
    public StockRepository(
        ILogger<RepositoryBase<Stock>> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }

    public Stock? GetStock(StockMarkets stockMarket, string stockCode)
        => this.DbContext.Find<Stock>(stockMarket, stockCode);

    public async Task<Stock?> GetStockAsync(StockMarkets stockMarket, string stockCode)
        => await this.DbContext.FindAsync<Stock>(stockMarket, stockCode);
}
