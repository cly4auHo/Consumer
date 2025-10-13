using Consumer.Config;
using Microsoft.EntityFrameworkCore;

namespace Consumer.DTO;

public class PriceREPO(AppDbContextFactory dbContextFactory) : IPriceREPO
{
    public async Task DoRecord(CurrencyEntity model)
    {
        await using var dbContext = dbContextFactory.CreateDbContext();

        dbContext.Currency.Add(model);
        
        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
        }
    }
}