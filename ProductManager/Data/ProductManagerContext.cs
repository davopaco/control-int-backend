using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

public class ProductManagerContext(DbContextOptions<ProductManagerContext> options) : DbContext(options)
{
    public DbSet<Producto> Productos => Set<Producto>();
}