using System.Net.Http.Json;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Stocks;
using IntelligentInvestor.Spider.UData.Domain;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.UData.Stocks;

[Obsolete("Token expired")]
public class UDataHotStockSpider : IHotStockSpider
{
    private readonly ILogger<UDataHotStockSpider> logger;
    private readonly StockCodeMarketParser stockCodeMarketParser;
    private readonly HttpClient httpClient;

    public UDataHotStockSpider(
        ILogger<UDataHotStockSpider> logger,
        StockCodeMarketParser stockCodeMarketParser,
        HttpClient httpClient)
    {
        this.logger = logger;
        this.stockCodeMarketParser = stockCodeMarketParser;
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Stock>> GetHotStocksAsync()
    {
        var response = await httpClient.GetFromJsonAsync<UDataResponse<UDataHotStock>>("udata/business/v1/app_services/market_info/lh_daily?fields=secu_abbr,secu_code");
        if (!"0".Equals(response.ErrorCode)) throw new InvalidOperationException(response.ErrorInfo);
        var stocks = response.Datas
            .Where(x => !string.IsNullOrWhiteSpace(x.StockName))
            .Select(x => this.stockCodeMarketParser.TryParse(x.StockCodeMarket, out var stockMarket, out var stockCode) ?
                new Stock(stockMarket, stockCode) { StockName = x.StockName } : default)
            .Where(x => x is not null)
            .ToList();
        return stocks;
    }
}
