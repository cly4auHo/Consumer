namespace Consumer.API;

[Serializable]
public class PriceRequestData
{
    public string Symbol { get; set; }
    public double Price { get; set; }
}