using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.Companys;

public interface ICompanySpider
{
    Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode);
}
