using Consumer;
using Consumer.Config;
using Consumer.DTO;
using Consumer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<HostedService>();
builder.Services.AddSingleton<ICollectionService, CollectionService>();
builder.Services.AddSingleton<AppDbContextFactory, AppDbContextFactory>();
builder.Services.AddSingleton<IDataRepo, DataRepo>();

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<Microsoft.Extensions.Options.IOptions<AppSettings>>().Value);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();