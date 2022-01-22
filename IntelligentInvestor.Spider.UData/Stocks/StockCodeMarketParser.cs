using System.Text.RegularExpressions;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Spider.UData.Stocks;

public class StockCodeMarketParser
{
    private readonly Regex stockCodeMarketRegex = new Regex(
        "(?<Code>\\d+)(\\.(?<Market>[a-zA-Z]+))?",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

    public StockCodeMarketParser()
    {
    }

    public bool TryParse(string stockCodeMarket, out StockMarkets stockMarket, out string stockCode)
    {
        stockMarket = StockMarkets.NotSpecified;
        stockCode = null;
        var match = this.stockCodeMarketRegex.Match(stockCodeMarket);
        if (!match.Success) return false;

        stockCode = match.Groups["Code"].Value;
        stockMarket = match.Groups["Market"].Value.ToUpper() switch
        {
            "SS" => StockMarkets.ShangHai,
            "SH" => StockMarkets.ShangHai,
            "HK" => StockMarkets.HongKong,
            "SZ" => StockMarkets.ShenZhen,
            _ => StockMarkets.NotSpecified,
        };
        return true;
    }
}
