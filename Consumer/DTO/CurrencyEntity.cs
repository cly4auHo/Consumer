namespace Consumer.DTO;

[Serializable]
public class CurrencyEntity
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public double Price { get; set; }
    public DateTimeOffset Time { get; set; }
}