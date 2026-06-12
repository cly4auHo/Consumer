namespace Consumer.API;

[Serializable]
public class PriceRequestData
{
    public string symbol { get; set; }
    public double price { get; set; }
}