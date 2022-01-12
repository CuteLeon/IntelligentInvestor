namespace IntelligentInvestor.Domain.Stocks;

public abstract class StockBase
{
    public StockBase()
    {
    }

    public StockBase(StockMarkets stockMarket, string stockCode)
    {
        this.StockCode = stockCode;
        this.StockMarket = stockMarket;
    }

    public string StockCode { get; set; }

    public StockMarkets StockMarket { get; set; }
}
