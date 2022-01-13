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

        builder.Entity<Stock>().HasKey(x => new { x.StockMarket, x.StockCode });
        builder.Entity<Quote>().HasKey(x => new { x.StockMarket, x.StockCode, x.Frequency, x.QuoteTime });
        builder.Entity<Company>().HasKey(x => new { x.StockMarket, x.StockCode });
        builder.Entity<TradeStrand>().HasKey(x => new { x.StockMarket, x.StockCode, x.QuoteTime });
        builder.Entity<GenericOption>().HasKey(x => new { x.OptionName, x.OwnerLevel, x.Category });

        builder.Entity<Stock>().HasOne(x => x.Company).WithOne(x => x.Stock).HasForeignKey<Company>(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey<Stock>(x => new { x.StockMarket, x.StockCode }).IsRequired();
        builder.Entity<Quote>().HasOne(x => x.Stock).WithMany().HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired();
        builder.Entity<TradeStrand>().HasOne(x => x.Stock).WithMany().HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlite("DATA SOURCE=IntelligentInvestor.db"));
    }
}
