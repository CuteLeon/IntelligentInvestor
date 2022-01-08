namespace IntelligentInvestor.Domain.Stocks;

public abstract class StockBase
{
    public StockBase()
    {
    }

    public StockBase(string stockCode, StockMarkets stockMarket)
    {
        this.StockCode = stockCode;
        this.StockMarket = stockMarket;
    }

    public string StockCode { get; set; }

    public StockMarkets StockMarket { get; set; }

    public string StockName { get; set; }

    public override string ToString() => $"{this.StockName} ({this.StockMarket}-{this.StockCode})";
}
