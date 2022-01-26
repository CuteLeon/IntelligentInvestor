using System.Text.Json.Serialization;

namespace IntelligentInvestor.Spider.UData.Domain;

public class UDataQuote
{
    [JsonPropertyName("date")]
    public DateTime QuoteDate { get; set; }

    [JsonPropertyName("time")]
    public int QuoteTime { get; set; }

    public decimal ClosingPriceYesterday { get; set; }

    [JsonPropertyName("open")]
    public decimal OpenningPrice { get; set; }

    [JsonPropertyName("close")]
    public decimal ClosingPrice { get; set; }

    [JsonPropertyName("high")]
    public decimal HighestPrice { get; set; }

    [JsonPropertyName("low")]
    public decimal LowestPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    [JsonPropertyName("change")]
    public string FluctuatingRange { get; set; }

    [JsonPropertyName("change_pct")]
    public string FluctuatingRate { get; set; }

    [JsonPropertyName("turnover_volume")]
    public decimal Volume { get; set; }

    [JsonPropertyName("turnover_value")]
    public decimal Amount { get; set; }
}
