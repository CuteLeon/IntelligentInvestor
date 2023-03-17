using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentInvestor.Infrastructure.Migrations;

public partial class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "GenericOptions",
            columns: table => new
            {
                OptionName = table.Column<string>(type: "TEXT", nullable: false),
                Category = table.Column<string>(type: "TEXT", nullable: false),
                OwnerLevel = table.Column<string>(type: "TEXT", nullable: false),
                OptionValue = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_GenericOptions", x => new { x.OptionName, x.OwnerLevel, x.Category });
            });

        _ = migrationBuilder.CreateTable(
            name: "Stocks",
            columns: table => new
            {
                StockCode = table.Column<string>(type: "TEXT", nullable: false),
                StockMarket = table.Column<int>(type: "INTEGER", nullable: false),
                StockName = table.Column<string>(type: "TEXT", nullable: false),
                IsSelected = table.Column<bool>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Stocks", x => new { x.StockMarket, x.StockCode });
            });

        _ = migrationBuilder.CreateTable(
            name: "Companies",
            columns: table => new
            {
                StockCode = table.Column<string>(type: "TEXT", nullable: false),
                StockMarket = table.Column<int>(type: "INTEGER", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Rank = table.Column<string>(type: "TEXT", nullable: true),
                Vote = table.Column<int>(type: "INTEGER", nullable: false),
                Location = table.Column<string>(type: "TEXT", nullable: true),
                Summary = table.Column<string>(type: "TEXT", nullable: true),
                Industry = table.Column<string>(type: "TEXT", nullable: true),
                Description = table.Column<string>(type: "TEXT", nullable: true),
                Status = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Companies", x => new { x.StockMarket, x.StockCode });
                _ = table.ForeignKey(
                    name: "FK_Companies_Stocks_StockMarket_StockCode",
                    columns: x => new { x.StockMarket, x.StockCode },
                    principalTable: "Stocks",
                    principalColumns: new[] { "StockMarket", "StockCode" },
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "Quotes",
            columns: table => new
            {
                StockCode = table.Column<string>(type: "TEXT", nullable: false),
                StockMarket = table.Column<int>(type: "INTEGER", nullable: false),
                QuoteTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                ClosingPriceYesterday = table.Column<decimal>(type: "TEXT", nullable: false),
                OpenningPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                ClosingPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                HighestPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                LowestPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                CurrentPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                FluctuatingRange = table.Column<decimal>(type: "TEXT", nullable: false),
                FluctuatingRate = table.Column<decimal>(type: "TEXT", nullable: false),
                Volume = table.Column<decimal>(type: "TEXT", nullable: false),
                Amount = table.Column<decimal>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Quotes", x => new { x.StockMarket, x.StockCode, x.Frequency, x.QuoteTime });
                _ = table.ForeignKey(
                    name: "FK_Quotes_Stocks_StockMarket_StockCode",
                    columns: x => new { x.StockMarket, x.StockCode },
                    principalTable: "Stocks",
                    principalColumns: new[] { "StockMarket", "StockCode" },
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "TradeStrands",
            columns: table => new
            {
                StockCode = table.Column<string>(type: "TEXT", nullable: false),
                StockMarket = table.Column<int>(type: "INTEGER", nullable: false),
                QuoteTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                BiddingPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                AuctionPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                BuyStrand1 = table.Column<long>(type: "INTEGER", nullable: false),
                BuyPrice1 = table.Column<decimal>(type: "TEXT", nullable: false),
                BuyStrand2 = table.Column<long>(type: "INTEGER", nullable: false),
                BuyPrice2 = table.Column<decimal>(type: "TEXT", nullable: false),
                BuyStrand3 = table.Column<long>(type: "INTEGER", nullable: false),
                BuyPrice3 = table.Column<decimal>(type: "TEXT", nullable: false),
                BuyStrand4 = table.Column<long>(type: "INTEGER", nullable: false),
                BuyPrice4 = table.Column<decimal>(type: "TEXT", nullable: false),
                BuyStrand5 = table.Column<long>(type: "INTEGER", nullable: false),
                BuyPrice5 = table.Column<decimal>(type: "TEXT", nullable: false),
                SellStrand1 = table.Column<long>(type: "INTEGER", nullable: false),
                SellPrice1 = table.Column<decimal>(type: "TEXT", nullable: false),
                SellStrand2 = table.Column<long>(type: "INTEGER", nullable: false),
                SellPrice2 = table.Column<decimal>(type: "TEXT", nullable: false),
                SellStrand3 = table.Column<long>(type: "INTEGER", nullable: false),
                SellPrice3 = table.Column<decimal>(type: "TEXT", nullable: false),
                SellStrand4 = table.Column<long>(type: "INTEGER", nullable: false),
                SellPrice4 = table.Column<decimal>(type: "TEXT", nullable: false),
                SellStrand5 = table.Column<long>(type: "INTEGER", nullable: false),
                SellPrice5 = table.Column<decimal>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_TradeStrands", x => new { x.StockMarket, x.StockCode, x.QuoteTime });
                _ = table.ForeignKey(
                    name: "FK_TradeStrands_Stocks_StockMarket_StockCode",
                    columns: x => new { x.StockMarket, x.StockCode },
                    principalTable: "Stocks",
                    principalColumns: new[] { "StockMarket", "StockCode" },
                    onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "Companies");

        _ = migrationBuilder.DropTable(
            name: "GenericOptions");

        _ = migrationBuilder.DropTable(
            name: "Quotes");

        _ = migrationBuilder.DropTable(
            name: "TradeStrands");

        _ = migrationBuilder.DropTable(
            name: "Stocks");
    }
}
