using System.Drawing;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider;

public interface IStockSpider
{
    Task<(Stock Stock, Quota Quota)> GetStockQuotaAsync(string code, StockMarkets market);

    Task<Image> GetChartAsync(string code, StockMarkets market, QuotaFrequencys quotaFrequency);

    Task<Company> GetCompanyAsync(string code, StockMarkets market);

    Task<List<Quota>> GetQuotasAsync(string code, StockMarkets market, QuotaFrequencys quotaFrequency, DateTime fromDate, DateTime toDate);

    Task<List<Stock>> GetHotStocksAsync();

    Task<List<Stock>> SearchStocksAsync(string keyword);
}
