using System.Net.Http.Json;
using IntelligentInvestor.Domain.Quotes;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Domain.Trades;
using IntelligentInvestor.Spider.Quotes;
using IntelligentInvestor.Spider.UData.Domain;
using IntelligentInvestor.Spider.UData.Stocks;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.UData.Quotes;

[Obsolete("Token expired")]
public class UDataQuoteSpider : IQuoteSpider
{
    private readonly ILogger<UDataQuoteSpider> logger;
    private readonly HttpClient httpClient;
    private readonly StockCodeMarketParser stockCodeMarketParser;

    public UDataQuoteSpider(
        ILogger<UDataQuoteSpider> logger,
        StockCodeMarketParser stockCodeMarketParser,
        HttpClient httpClient)
    {
        this.logger = logger;
        this.stockCodeMarketParser = stockCodeMarketParser;
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Quote>> GetQuotesAsync(StockMarkets stockMarket, string stockCode, QuoteFrequencys quoteFrequency, DateTime? fromDate, DateTime? toDate)
    {
        var frequency = quoteFrequency switch
        {
            QuoteFrequencys.Trading => "stock_quote_minutes",
            QuoteFrequencys.Daily => "stock_quote_daily",
            QuoteFrequencys.Weekly => "stock_quote_weekly",
            QuoteFrequencys.Monthly => "stock_quote_monthly",
            QuoteFrequencys.Yearly => "stock_quote_yearly",
            _ => "stock_quote_daily_list"
        };
        var market = stockMarket switch
        {
            StockMarkets.HongKong => "HK",
            StockMarkets.ShenZhen => "SZ",
            StockMarkets.ShangHai => "SH",
            _ => "SH",
        };
        var queryString = $"en_prod_code={stockCode}.{market}";
        if (fromDate.HasValue) queryString += $"&begin_date={fromDate!:yyyy-MM-dd}";
        if (toDate.HasValue) queryString += $"&end_date={toDate!:yyyy-MM-dd}";

        var response = await httpClient.GetFromJsonAsync<UDataResponse<UDataQuote>>($"udata/business/v1/app_services/market_info/{frequency}?{queryString}");
        if (!"0".Equals(response.ErrorCode)) throw new InvalidOperationException(response.ErrorInfo);
        var result = response.Datas.Select(x => new Quote()
        {
            Amount = x.Amount,
            ClosingPrice = x.ClosingPrice,
            FluctuatingRange = string.IsNullOrWhiteSpace(x.FluctuatingRange) ? 0 : Convert.ToDecimal(x.FluctuatingRange),
            FluctuatingRate = string.IsNullOrWhiteSpace(x.FluctuatingRate) ? 0 : Convert.ToDecimal(x.FluctuatingRate),
            Frequency = quoteFrequency,
            HighestPrice = x.HighestPrice,
            LowestPrice = x.LowestPrice,
            OpenningPrice = x.OpenningPrice,
            StockCode = stockCode,
            StockMarket = stockMarket,
            Volume = x.Volume,
            QuoteTime = x.QuoteDate
                .AddHours(x.QuoteTime / 100)
                .AddMinutes(x.QuoteTime % 100),
        }).ToArray();
        return result;
    }

    public async Task<(Quote Quote, TradeStrand TradeStrand)> GetQuoteAsync(StockMarkets stockMarket, string stockCode)
    {
        return default;
    }
}
