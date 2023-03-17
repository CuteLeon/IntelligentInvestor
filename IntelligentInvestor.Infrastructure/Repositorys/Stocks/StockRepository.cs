using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Infrastructure.Repositorys.Stocks;

public class StockRepository : RepositoryBase<Stock>, IStockRepository
{
    public StockRepository(
        ILogger<StockRepository> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }

    public async Task<IEnumerable<Stock?>> SearchStocksAsync(string? keyword = null, bool? isSelected = null)
    {
        var query = this.Set().AsQueryable<Stock>();
        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(x => EF.Functions.Like(x.StockCode, $"%{keyword}%") || EF.Functions.Like(x.StockName, $"%{keyword}%"));
        if (isSelected.HasValue) query = query.Where(x => x.IsSelected == isSelected.Value);

        return await query.ToListAsync();
    }

    public Stock? GetStock(StockMarkets stockMarket, string stockCode)
    {
        return this.DbContext.Find<Stock>(stockMarket, stockCode);
    }

    public async Task<Stock?> GetStockAsync(StockMarkets stockMarket, string stockCode)
    {
        return await this.DbContext.FindAsync<Stock>(stockMarket, stockCode);
    }

    public Stock AddOrUpdateStock(Stock stock)
    {
        return this.Set().Any(x => x.StockMarket == stock.StockMarket && x.StockCode == stock.StockCode)
            ? this.Update(stock)
            : this.Add(stock);
    }

    public async Task<Stock> AddOrUpdateStockAsync(Stock stock)
    {
        return await this.Set().AnyAsync(x => x.StockMarket == stock.StockMarket && x.StockCode == stock.StockCode)
            ? await this.UpdateAsync(stock)
            : await this.AddAsync(stock);
    }
}
