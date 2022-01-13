using System.Drawing;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Spider;

public interface IStockSpider
{
    Task<(Quota Quota, TradeStrand TradeStrand)> GetStockQuotaAsync(StockMarkets stockMarket, string stockCode);

    Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuotaFrequencys quotaFrequency);

    Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode);

    Task<IEnumerable<Quota>> GetQuotasAsync(StockMarkets stockMarket, string stockCode, QuotaFrequencys quotaFrequency, DateTime fromDate, DateTime toDate);

    Task<IEnumerable<Stock>> GetHotStocksAsync();

    Task<IEnumerable<Stock>> SearchStocksAsync(string keyword);
}
