using IntelligentInvestor.Domain.Quotas;

namespace IntelligentInvestor.Domain.Comparers;

public class QuotaBaseComparer<TStockTimelyBase> : StockBaseComparer<TStockTimelyBase>
    where TStockTimelyBase : QuotaBase
{
    public override int Compare(TStockTimelyBase x, TStockTimelyBase y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x != null && y == null) return 1;
        if (x == null && y != null) return -1;

        int result = base.Compare(x!, y!);
        if (result != 0) return result;

        return x!.QuotaTime > y!.QuotaTime ? 1 : -1;
    }

    public override bool Equals(TStockTimelyBase x, TStockTimelyBase y)
    {
        bool result = base.Equals(x, y);
        if (!result) return result;

        return x!.QuotaTime == y!.QuotaTime;
    }
}
