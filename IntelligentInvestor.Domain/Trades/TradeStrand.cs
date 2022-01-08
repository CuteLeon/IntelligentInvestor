using IntelligentInvestor.Domain.Quotas;

namespace IntelligentInvestor.Domain.Trades;

public class TradeStrand : QuotaBase
{
    public long BuyStrand1 { get; set; }

    public double BuyPrice1 { get; set; }

    public long BuyStrand2 { get; set; }

    public double BuyPrice2 { get; set; }

    public long BuyStrand3 { get; set; }

    public double BuyPrice3 { get; set; }

    public long BuyStrand4 { get; set; }

    public double BuyPrice4 { get; set; }

    public long BuyStrand5 { get; set; }

    public double BuyPrice5 { get; set; }

    public long SellStrand1 { get; set; }

    public double SellPrice1 { get; set; }

    public long SellStrand2 { get; set; }

    public double SellPrice2 { get; set; }

    public long SellStrand3 { get; set; }

    public double SellPrice3 { get; set; }

    public long SellStrand4 { get; set; }

    public double SellPrice4 { get; set; }

    public long SellStrand5 { get; set; }

    public double SellPrice5 { get; set; }
}
