using IntelligentInvestor.Domain.Quotes;

namespace IntelligentInvestor.Domain.Comparers;

public class QuoteBaseComparer<TStockTimelyBase> : StockBaseComparer<TStockTimelyBase>
    where TStockTimelyBase : QuoteBase
{
    public override int Compare(TStockTimelyBase x, TStockTimelyBase y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x != null && y == null) return 1;
        if (x == null && y != null) return -1;

        var result = base.Compare(x!, y!);
        return result != 0 ? result : x!.QuoteTime > y!.QuoteTime ? 1 : -1;
    }

    public override bool Equals(TStockTimelyBase x, TStockTimelyBase y)
    {
        var result = base.Equals(x, y);
        return !result ? result : x!.QuoteTime == y!.QuoteTime;
    }
}
