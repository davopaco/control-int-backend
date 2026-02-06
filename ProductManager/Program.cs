using ProductManager.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddProductosDatabase();
builder.AddScopedInstances();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.MigrateDb();

app.Run();
