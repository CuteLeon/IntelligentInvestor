using IntelligentInvestor.Domain.Companys;
using IntelligentInvestor.Domain.Stocks;
using IntelligentInvestor.Spider.Stocks;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using IntelligentInvestor.Spider.UData.Domain;

namespace IntelligentInvestor.Spider.UData.Stocks;

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

    public async Task<Company> GetCompanyAsync(StockMarkets stockMarket, string stockCode)
    {
        return default;
    }

    public async Task<IEnumerable<Stock>> GetHotStocksAsync()
    {
        var response = await httpClient.GetFromJsonAsync<UDataResponse<DailyHotStock>>("udata/business/v1/app_services/market_info/lh_daily?fields=secu_abbr,secu_code");
        if (!"0".Equals(response.ErrorCode)) throw new InvalidOperationException(response.ErrorInfo);
        var stocks = response.Datas
            .Where(x => !string.IsNullOrWhiteSpace(x.StockName))
            .Select(x =>
            {
                var (stockMarket, stockCode) = this.stockCodeMarketParser.Parse(x.StockCodeMarket);
                return new Stock(stockMarket, stockCode) { StockName = x.StockName };
            }).ToList();
        return stocks;
    }

    public async Task<IEnumerable<Stock>> SearchStocksAsync(string keyword)
    {
        return default;
    }
}
