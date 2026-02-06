using ProductManager.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddProductosDatabase();
builder.AddScopedInstances();
builder.Services.AddControllers();

//TODO: Remueve antes de prod
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors("AllowAngularDev");

app.MapControllers();
app.MigrateDb();

app.Run();
