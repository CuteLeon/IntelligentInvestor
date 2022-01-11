﻿using IntelligentInvestor.Domain.Companys;
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

        builder.Entity<Company>().HasOne(x => x.Stock).WithOne(x => x.Company).HasForeignKey<Company>(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey<Stock>(x => new { x.StockMarket, x.StockCode }).IsRequired(false);
        builder.Entity<Quota>().HasOne(x => x.Stock).WithMany(x => x.Quotas).HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired(false);
        builder.Entity<TradeStrand>().HasOne(x => x.Stock).WithMany(x => x.TradeStrands).HasForeignKey(x => new { x.StockMarket, x.StockCode }).HasPrincipalKey(x => new { x.StockMarket, x.StockCode }).IsRequired(false);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlite("DATA SOURCE=IIDB.db"));
    }
}
