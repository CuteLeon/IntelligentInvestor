using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.Stocks;

public interface IStockSpider
{
    Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode);

    Task<IEnumerable<Stock>> GetHotStocksAsync();

    Task<IEnumerable<Stock>> SearchStocksAsync(string keyword);
}
