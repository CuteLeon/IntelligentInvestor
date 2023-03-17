using System.Text;
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
        "(?<Market>[a-zA-z]+)(?<Code>\\d+),(?<Name>.+?),(.*?){4},.*?;",
         RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

    public SinaStockSpider(
        ILogger<SinaStockSpider> logger,
        HttpClient httpClient)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        this.logger = logger;
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException(null, nameof(keyword));

        var request = $"https://suggest3.sinajs.cn/suggest/key={keyword}";
        var result = await this.httpClient.GetStringAsync(request);
        var matches = this.searchStockRegex.Matches(result);
        var stocks = matches.Cast<Match>()
            .Where(m => m.Success)
            .Select(m =>
            {
                var code = m.Groups["Code"].Value;
                var name = m.Groups["Name"].Value;
                var marketName = m.Groups["Market"].Value.ToLower();
                var market = marketName switch
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
