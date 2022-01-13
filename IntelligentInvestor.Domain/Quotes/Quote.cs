using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Quotes;

public class Quote : QuoteBase
{
    public Quote() : base()
    {
    }

    public Quote(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public QuoteFrequencys Frequency { get; set; } = QuoteFrequencys.Trade;

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
