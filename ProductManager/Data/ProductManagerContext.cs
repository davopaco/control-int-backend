using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

public class ProductManagerContext(DbContextOptions<ProductManagerContext> options) : DbContext(options)
{
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Estado> Estado => Set<Estado>();
    public DbSet<Imagen> Imagenes => Set<Imagen>();
    public DbSet<ImagenProductos> ImagenesProductos => Set<ImagenProductos>();
}