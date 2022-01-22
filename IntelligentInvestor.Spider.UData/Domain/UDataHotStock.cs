using System.Text.Json.Serialization;

namespace IntelligentInvestor.Spider.UData.Domain;

public class UDataHotStock
{
    [JsonPropertyName("secu_abbr")]
    public string StockName { get; set; }

    [JsonPropertyName("secu_code")]
    public string StockCodeMarket { get; set; }
}
