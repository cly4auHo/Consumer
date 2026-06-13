using Consumer.Config;

namespace Consumer.DTO;

public class DataRepo(AppDbContextFactory dbContextFactory) : IDataRepo
{
    public async Task<bool> DoRecord(CurrencyEntity entity)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();

        dbContext.Currency.Add(entity);
        
        try
        {
            var result = await dbContext.SaveChangesAsync();
            
            return result == 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}