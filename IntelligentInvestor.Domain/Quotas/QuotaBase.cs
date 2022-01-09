using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Quotas;

public abstract class QuotaBase : StockBase
{
    public QuotaBase() : base()
    {
    }

    public QuotaBase(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public DateTime QuotaTime { get; set; }

    public virtual Stock Stock { get; set; }
}
