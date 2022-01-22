using System.Text.Json.Serialization;

namespace IntelligentInvestor.Spider.UData.Domain;

public class UDataStock
{
    [JsonPropertyName("secu_abbr")]
    public string StockName { get; set; }

    [JsonPropertyName("hs_code")]
    public string StockCodeMarket { get; set; }
}
