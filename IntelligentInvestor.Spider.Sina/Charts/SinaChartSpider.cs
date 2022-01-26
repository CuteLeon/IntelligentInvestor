using System.Drawing;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Charts;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Mock.Charts;

public class SinaChartSpider : IChartSpider
{
    private readonly ILogger<SinaChartSpider> logger;
    private readonly HttpClient httpClient;

    public SinaChartSpider(
        ILogger<SinaChartSpider> logger,
        HttpClient httpClient)
    {
        this.logger = logger;
        this.httpClient = httpClient;
    }

    public async Task<Image> GetChartAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency)
    {
        var frequency = quoteFrequency switch
        {
            QuoteFrequencys.Trading => "min",
            QuoteFrequencys.Daily => "daily",
            QuoteFrequencys.Weekly => "weekly",
            QuoteFrequencys.Monthly => "monthly",
            _ => throw new ArgumentException(null, nameof(quoteFrequency)),
        };
        var market = stockMarket switch
        {
            StockMarkets.HongKong => "hk",
            StockMarkets.ShenZhen => "sz",
            StockMarkets.ShangHai => "sh",
            _ => throw new ArgumentException(null, nameof(stockMarket)),
        };
        var address = $"http://image.sinajs.cn/newchart/{frequency}/n/{market}{stockCode}.gif";
        var result = await this.httpClient.GetStreamAsync(address);

        Image image = Image.FromStream(result);
        return image;
    }
}
