using Microsoft.EntityFrameworkCore;
using ProductManager.Services;

namespace ProductManager.Data;

public static class DataExtensions
{
    //Función helper para que se migre la base de datos, basado en el modelo, al DBMS.
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagerContext>();
        dbContext.Database.Migrate();
    }

    //Aquí se inicializa el contexto para el ORM
    public static void AddProductosDatabase(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("ProductConnection");

        builder.Services.AddDbContext<ProductManagerContext>(optionsAction: options =>
        {
            options.UseMySql(connString, ServerVersion.AutoDetect(connString));
        });
    }

    //Aqui se establecen las instances Service en patrón de Scope
    public static void AddScopedInstances(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ProductsService>();
        builder.Services.AddScoped<EstadosService>();
        builder.Services.AddScoped<ImagenesService>();
    }
}
