using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;

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
}
