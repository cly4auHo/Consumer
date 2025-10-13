using Consumer.DTO;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Config;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CurrencyEntity> Currency { get; set; }
}