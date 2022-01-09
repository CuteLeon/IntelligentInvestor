using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Quotas;

public class Quota : QuotaBase
{
    public Quota() : base()
    {
    }

    public Quota(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public QuotaFrequencys Frequency { get; set; }

    public decimal ClosingPriceYesterday { get; set; }

    public decimal OpenningPrice { get; set; }

    public decimal ClosingPrice { get; set; }

    public decimal HighestPrice { get; set; }

    public decimal LowestPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal FluctuatingRange { get; set; }

    public decimal FluctuatingRate { get; set; }

    public decimal Volume { get; set; }

    public decimal Amount { get; set; }
}
