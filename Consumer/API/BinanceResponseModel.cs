using System.Text.Json.Serialization;

namespace Consumer.API;

public class BinanceResponseModel
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
    
    [JsonPropertyName("price")]
    public string Price { get; set; } 
}