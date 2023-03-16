using System.Net.Http.Json;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Stocks;
using IntelligentInvestor.Spider.UData.Domain;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Spider.UData.Stocks;

[Obsolete("Token expired")]
public class UDataStockSpider : IStockSpider
{
    private readonly ILogger<UDataStockSpider> logger;
    private readonly StockCodeMarketParser stockCodeMarketParser;
    private readonly HttpClient httpClient;

    public UDataStockSpider(
        ILogger<UDataStockSpider> logger,
        StockCodeMarketParser stockCodeMarketParser,
        HttpClient httpClient)
    {
        this.logger = logger;
        this.stockCodeMarketParser = stockCodeMarketParser;
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        var response = await httpClient.GetFromJsonAsync<UDataResponse<UDataStock>>("udata/business/v1/app_services/basic_data/stock_list?fields=secu_abbr,hs_code");
        if (!"0".Equals(response.ErrorCode)) throw new InvalidOperationException(response.ErrorInfo);
        var stocks = response.Datas
            .Where(x => x.StockName.Contains(keyword) || x.StockCodeMarket.Contains(keyword))
            .Select(x => this.stockCodeMarketParser.TryParse(x.StockCodeMarket, out var stockMarket, out var stockCode) ?
                new Stock(stockMarket, stockCode) { StockName = x.StockName } : default)
            .Where(x => x is not null)
            .ToList();
        return stocks;
    }
}
