using System.Drawing;
using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Spider;

public interface IStockSpider
{
    Task<(Quote Quote, TradeStrand TradeStrand)> GetStockQuoteAsync(StockMarkets stockMarket, string stockCode);

    Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency);

    Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode);

    Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime fromDate, DateTime toDate);

    Task<IEnumerable<Stock>> GetHotStocksAsync();

    Task<IEnumerable<Stock>> SearchStocksAsync(string keyword);
}
