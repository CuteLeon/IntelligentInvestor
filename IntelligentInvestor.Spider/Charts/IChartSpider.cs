using System.Drawing;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.Charts;

public interface IChartSpider
{
    Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency);
}
