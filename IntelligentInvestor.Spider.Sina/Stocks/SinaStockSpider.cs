using System.Text.RegularExpressions;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.Sina.Stocks;

public class SinaStockSpider : IStockSpider
{
    private readonly ILogger<SinaStockSpider> logger;
    private readonly HttpClient httpClient;
    private readonly Regex searchStockRegex = new(
        "(?<Market>[a-zA-z]*?)(?<Code>\\d+?),(.+?,){3}(?<Name>.+?),.*?;",
         RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

    public SinaStockSpider(
        ILogger<SinaStockSpider> logger,
        HttpClient httpClient)
    {
        this.logger = logger;
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException(null, nameof(keyword));

        string request = $"https://suggest3.sinajs.cn/suggest/key={keyword}";
        var result = await this.httpClient.GetStringAsync(request);

        var matches = this.searchStockRegex.Matches(result);
        var stocks = matches.Cast<Match>()
            .Where(m => m.Success)
            .Select(m =>
            {
                var code = m.Groups["Code"].Value;
                var name = m.Groups["Name"].Value;
                var market = m.Groups["Market"].Value.ToUpper() switch
                {
                    "hk" => StockMarkets.HongKong,
                    "sz" => StockMarkets.ShenZhen,
                    "sh" => StockMarkets.ShangHai,
                    _ => StockMarkets.NotSpecified
                };
                var stock = new Stock(market, code) { StockName = name };
                return stock;
            })
            .OrderBy(s => s.StockName)
            .ToList();
        return stocks;
    }
}
