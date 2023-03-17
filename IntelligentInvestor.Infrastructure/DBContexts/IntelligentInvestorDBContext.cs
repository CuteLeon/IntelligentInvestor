using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Options;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using Microsoft.EntityFrameworkCore;

namespace IntelligentInvestor.Infrastructure.DBContexts;

public class IntelligentInvestorDBContext : DbContext
{
    public IntelligentInvestorDBContext() : base()
    {
    }

    public IntelligentInvestorDBContext(
        DbContextOptions<IntelligentInvestorDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<TradeStrand> TradeStrands { get; set; }

    public virtual DbSet<GenericOption> GenericOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _ = builder.Entity<Stock>().HasKey(x => new { x.StockMarket, x.StockCode });
        _ = builder.Entity<Quote>().HasKey(x => new { x.StockMarket, x.StockCode, x.Frequency, x.QuoteTime });
        _ = builder.Entity<Company>().HasKey(x => new { x.StockMarket, x.StockCode });
        _ = builder.Entity<TradeStrand>().HasKey(x => new { x.StockMarket, x.StockCode, x.QuoteTime });
        _ = builder.Entity<GenericOption>().HasKey(x => new { x.OptionName, x.OwnerLevel, x.Category });

        _ = builder.Entity<Stock>().HasOne(x => x.Company).WithOne(x => x.Stock).HasForeignKey<Company>(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey<Stock>(x => new { x.StockMarket, x.StockCode }).IsRequired();
        _ = builder.Entity<Quote>().HasOne(x => x.Stock).WithMany().HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired();
        _ = builder.Entity<TradeStrand>().HasOne(x => x.Stock).WithMany().HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlite("DATA SOURCE=IntelligentInvestor.db"));
    }
}
