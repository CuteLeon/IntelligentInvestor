using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Comparers;

public class StockBaseComparer<TStockBase> : IEqualityComparer<TStockBase>, IComparer<TStockBase>
        where TStockBase : StockBase
{
    public virtual int Compare(TStockBase x, TStockBase y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x != null && y == null) return 1;
        if (x == null && y != null) return -1;

        if (x!.StockMarket != y!.StockMarket)
            return x.StockMarket > y.StockMarket ? 1 : -1;

        return string.Compare(x!.StockCode, y!.StockCode, StringComparison.OrdinalIgnoreCase);
    }

    public virtual bool Equals(TStockBase x, TStockBase y)
        => ReferenceEquals(x, y) || (x?.StockMarket == y?.StockMarket &&
        string.Equals(x?.StockCode, y?.StockCode, StringComparison.OrdinalIgnoreCase));

    public virtual int GetHashCode(TStockBase obj)
        => obj.GetHashCode();
}
