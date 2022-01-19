using System.Text.Json.Serialization;

namespace IntelligentInvestor.Spider.UData.Domain;

public class UDataResponse<TPayload>
{
    [JsonPropertyName("error_info")]
    public string ErrorInfo { get; set; }

    [JsonPropertyName("error_code")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<TPayload> Datas { get; set; }
}
