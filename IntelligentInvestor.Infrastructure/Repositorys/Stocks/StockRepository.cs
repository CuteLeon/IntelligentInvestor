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

    public async Task<IEnumerable<Stock?>> SearchStocksAsync(string? keyword = null, bool? isSelected = null)
    {
        var query = this.Set().AsQueryable<Stock>();
        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(x => EF.Functions.Like(x.StockCode, $"%{keyword}%") || EF.Functions.Like(x.StockName, $"%{keyword}%"));
        if (isSelected.HasValue) query = query.Where(x => x.IsSelected == isSelected.Value);

        return await query.ToListAsync();
    }

    public Stock? GetStock(StockMarkets stockMarket, string stockCode)
        => this.DbContext.Find<Stock>(stockMarket, stockCode);

    public async Task<Stock?> GetStockAsync(StockMarkets stockMarket, string stockCode)
        => await this.DbContext.FindAsync<Stock>(stockMarket, stockCode);

    public Stock AddOrUpdateStock(Stock stock)
    {
        if (this.Set().Any(x => x.StockMarket == stock.StockMarket && x.StockCode == stock.StockCode))
            return this.Update(stock);
        else
            return this.Add(stock);
    }

    public async Task<Stock> AddOrUpdateStockAsync(Stock stock)
    {
        if (await this.Set().AnyAsync(x => x.StockMarket == stock.StockMarket && x.StockCode == stock.StockCode))
            return await this.UpdateAsync(stock);
        else
            return await this.AddAsync(stock);
    }
}
