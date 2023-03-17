using IntelligentInvestor.Domain.Companys;

namespace IntelligentInvestor.Domain.Stocks;

public class Stock : StockBase
{
    private const char FullCodeSpliter = '-';

    public Stock() : base()
    {
    }

    public Stock(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public string StockName { get; set; }

    public bool IsSelected { get; set; }

    public virtual Company Company { get; set; }

    public override string ToString()
    {
        return $"{this.StockName} ({this.StockMarket}-{this.StockCode})";
    }

    public string GetFullCode()
    {
        return $"{this.StockMarket}{FullCodeSpliter}{this.StockCode}{FullCodeSpliter}{this.StockName}";
    }

    public static (StockMarkets StockMarket, string StockCode, string StockName) GetMarketCode(string fullCode)
    {
        var values = fullCode.Split(new[] { FullCodeSpliter }, 3);
        return values.Length == 3
            ? ((StockMarkets StockMarket, string StockCode, string StockName))(Enum.TryParse(values[0], out StockMarkets stockMarket) ? stockMarket : StockMarkets.NotSpecified, values[1], values[2])
            : ((StockMarkets StockMarket, string StockCode, string StockName))(StockMarkets.NotSpecified, string.Empty, string.Empty);
    }
}
