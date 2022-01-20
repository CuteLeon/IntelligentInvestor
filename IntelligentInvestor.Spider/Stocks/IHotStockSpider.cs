using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.Stocks;

public interface IHotStockSpider
{
    Task<IEnumerable<Stock>> GetHotStocksAsync();
}
