using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;
using IntelligentInvestor.Domain.Trades;

namespace IntelligentInvestor.Domain.Stocks;

public class Stock : StockBase
{
    public Stock() : base()
    {
    }

    public Stock(string stockCode, StockMarkets stockMarket)
        : base(stockCode, stockMarket)
    {
    }

    public bool IsSelected { get; set; }

    public virtual Company Company { get; set; }

    public virtual List<Quota> Quotas { get; set; }

    public virtual List<TradeStrand> TradeStrands { get; set; }

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
