using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Quotas;
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

    public virtual DbSet<Quota> Quotas { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<TradeStrand> TradeStrands { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Stock>().HasKey(x => new { x.StockMarket, x.StockCode });
        builder.Entity<Quota>().HasKey(x => new { x.StockMarket, x.StockCode, x.Frequency, x.QuotaTime });
        builder.Entity<Company>().HasKey(x => new { x.StockMarket, x.StockCode });
        builder.Entity<TradeStrand>().HasKey(x => new { x.StockMarket, x.StockCode, x.QuotaTime });

        builder.Entity<Stock>().HasOne(x => x.Company).WithOne(x => x.Stock).HasForeignKey<Company>(x => new { x.StockMarket, x.StockCode }).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Stock>().HasMany(x => x.Quotas).WithOne(x => x.Stock).HasForeignKey(x => new { x.StockMarket, x.StockCode }).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Stock>().HasMany(x => x.TradeStrands).WithOne(x => x.Stock).HasForeignKey(x => new { x.StockMarket, x.StockCode }).OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlite("DATA SOURCE=MigrationGenerated.db"));
    }
}
