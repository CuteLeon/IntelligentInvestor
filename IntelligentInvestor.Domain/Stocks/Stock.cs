using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Domain.Stocks;

public class Stock : StockBase
{
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

    public override string ToString() => $"{this.StockName} ({this.StockMarket}-{this.StockCode})";

    public string GetFullCode()
        => $"{this.StockMarket}-{this.StockCode}-{this.StockName}";

    public static (string StockCode, StockMarkets StockMarket, string StockName) GetMarketCode(string fullCode)
    {
        var values = fullCode.Split(new[] { '-' }, 3);
        if (values.Length == 3)
        {
            return (values[0], Enum.TryParse(values[1], out StockMarkets stockMarket) ? stockMarket : StockMarkets.NotSpecified, values[2]);
        }
        else
        {
            return (string.Empty, StockMarkets.NotSpecified, string.Empty);
        }
    }
}
