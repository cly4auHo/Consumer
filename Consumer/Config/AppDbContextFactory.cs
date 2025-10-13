using Microsoft.EntityFrameworkCore; 

namespace Consumer.Config;

public class AppDbContextFactory : IDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=history_of_currency;Username=user;Password=password");

        return new AppDbContext(optionsBuilder.Options);
    }
}