namespace Consumer.DTO;

public class CurrencyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}