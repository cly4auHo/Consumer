using Microsoft.EntityFrameworkCore;

namespace Consumer.Config;

public class AppDbContextFactory(AppSettings appSettings) : IDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(appSettings.ConnectionStrings["DefaultConnection"]);

        return new AppDbContext(optionsBuilder.Options);
    }
}