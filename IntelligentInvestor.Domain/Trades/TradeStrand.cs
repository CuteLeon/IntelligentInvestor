using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Trades;

public class TradeStrand : QuoteBase
{
    public TradeStrand() : base()
    {
    }

    public TradeStrand(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public decimal BiddingPrice { get; set; }

    public decimal AuctionPrice { get; set; }

    public long BuyStrand1 { get; set; }

    public decimal BuyPrice1 { get; set; }

    public long BuyStrand2 { get; set; }

    public decimal BuyPrice2 { get; set; }

    public long BuyStrand3 { get; set; }

    public decimal BuyPrice3 { get; set; }

    public long BuyStrand4 { get; set; }

    public decimal BuyPrice4 { get; set; }

    public long BuyStrand5 { get; set; }

    public decimal BuyPrice5 { get; set; }

    public long SellStrand1 { get; set; }

    public decimal SellPrice1 { get; set; }

    public long SellStrand2 { get; set; }

    public decimal SellPrice2 { get; set; }

    public long SellStrand3 { get; set; }

    public decimal SellPrice3 { get; set; }

    public long SellStrand4 { get; set; }

    public decimal SellPrice4 { get; set; }

    public long SellStrand5 { get; set; }

    public decimal SellPrice5 { get; set; }
}
