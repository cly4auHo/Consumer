namespace Consumer.API;

[Serializable]
public class PriceRequestData
{
    public string Symbol { get; set; }
    public string Price { get; set; }
}