using Microsoft.EntityFrameworkCore;
using ProductManager.Services;

namespace ProductManager.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagerContext>();
        dbContext.Database.Migrate();
    }

    public static void AddProductosDatabase(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("ProductConnection");

        builder.Services.AddDbContext<ProductManagerContext>(optionsAction: options =>
        {
            options.UseMySql(connString, ServerVersion.AutoDetect(connString));
        });
    }

    public static void AddScopedInstances(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ProductsService>();
        builder.Services.AddScoped<EstadosService>();
    }
}
