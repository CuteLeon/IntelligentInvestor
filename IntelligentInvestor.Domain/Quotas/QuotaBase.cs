using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Quotas;

public abstract class QuotaBase : StockBase
{
    public QuotaBase() : base()
    {
    }

    public QuotaBase(string stockCode, StockMarkets stockMarket)
        : base(stockCode, stockMarket)
    {
    }

    public DateTime QuotaTime { get; set; }

    public virtual Stock Stock { get; set; }
}
