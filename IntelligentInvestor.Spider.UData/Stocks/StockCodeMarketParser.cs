using System.Text.RegularExpressions;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.UData.Stocks;

public class StockCodeMarketParser
{
    private readonly Regex stockCodeMarketRegex = new Regex(
        "(?<Code>\\d+)\\.(?<Market>[a-zA-Z]+)",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

    public StockCodeMarketParser()
    {
    }

    public (StockMarkets StockMarket, string StockCode) Parse(string stockCodeMarket)
    {
        var match = this.stockCodeMarketRegex.Match(stockCodeMarket);
        if (!match.Success) throw new FormatException($"Stock code market format error: {stockCodeMarket}");

        var stockCode = match.Groups["Code"].Value;
        var stockMarket = match.Groups["Market"].Value.ToUpper() switch
        {
            "SS" => StockMarkets.ShangHai,
            "SH" => StockMarkets.ShangHai,
            "HK" => StockMarkets.HongKong,
            "SZ" => StockMarkets.ShenZhen,
            _ => StockMarkets.NotSpecified,
        };
        return (stockMarket, stockCode);
    }
}
