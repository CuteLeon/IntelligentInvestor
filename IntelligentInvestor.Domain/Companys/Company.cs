using IntelligentInvestor.Domain.Stocks;

namespace IntelligentInvestor.Domain.Companys;

public class Company : StockBase
{
    public Company() : base()
    {
    }

    public Company(StockMarkets stockMarket, string stockCode)
        : base(stockMarket, stockCode)
    {
    }

    public virtual Stock Stock { get; set; }

    public string Name { get; set; }

    public string Rank { get; set; }

    public int Vote { get; set; }

    public string Location { get; set; }

    public string Summary { get; set; }

    public string Industry { get; set; }

    public string Description { get; set; }

    public CompanyStatuses Status { get; set; }
}
