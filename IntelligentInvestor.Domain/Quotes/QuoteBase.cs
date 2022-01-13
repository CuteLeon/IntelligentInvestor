using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Quotes;

public abstract class QuoteBase : StockBase
{
    public QuoteBase() : base()
    {
    }

    public QuoteBase(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public DateTime QuoteTime { get; set; }

    public virtual Stock Stock { get; set; }

    public override string ToString() => $"{this.StockMarket}-{this.StockCode} ({this.Stock?.StockName}), AT {this.QuoteTime}";
}
