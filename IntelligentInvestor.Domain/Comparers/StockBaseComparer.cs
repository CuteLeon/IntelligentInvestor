using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Comparers;

public class StockBaseComparer<TStockBase> : IEqualityComparer<TStockBase>, IComparer<TStockBase>
        where TStockBase : StockBase
{
    public virtual int Compare(TStockBase x, TStockBase y)
    {
        return ReferenceEquals(x, y)
            ? 0
            : x != null && y == null
            ? 1
            : x == null && y != null
            ? -1
            : x!.StockMarket != y!.StockMarket
            ? x.StockMarket > y.StockMarket ? 1 : -1
            : string.Compare(x!.StockCode, y!.StockCode, StringComparison.OrdinalIgnoreCase);
    }

    public virtual bool Equals(TStockBase x, TStockBase y)
    {
        return ReferenceEquals(x, y) || (x?.StockMarket == y?.StockMarket &&
            string.Equals(x?.StockCode, y?.StockCode, StringComparison.OrdinalIgnoreCase));
    }

    public virtual int GetHashCode(TStockBase obj)
    {
        return obj.GetHashCode();
    }
}
