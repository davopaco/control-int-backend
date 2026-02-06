using Microsoft.EntityFrameworkCore;
using ProductManager.Dtos;
using ProductManager.Models;

namespace ProductManager.Services;

public class ProductsService(ProductManagerContext context)
{
    //Obtener todos los productos
    public async Task<List<ProductoDetailedDto>> GetAllProductos()
    {
        try
        {
            return await context.Productos.Include(prod => prod.Estado).Select(producto => ProductoDetailedDto.ProductosToDto(producto)).AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An issue occurred while obtaining products");
        }
    }

    //Obtener todos los productos ordenados por precio
    public async Task<List<ProductoDetailedDto>> GetAllProductosSorted()
    {
        try
        {
            return await context.Productos.OrderByDescending(prod => prod.Precio).Include(prod => prod.Estado).Select(producto => ProductoDetailedDto.ProductosToDto(producto)).AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An issue occurred while obtaining products");
        }
    }

    //Obtener el producto por ID
    public async Task<Information<ProductoDto>> GetProductoById(int id)
    {
        try
        {
            var producto = await context.Productos.FindAsync(id);

            if (producto is null)
            {
                return new Information<ProductoDto>(true, null);
            }

            return new Information<ProductoDto>(false, ProductoDto.ProductosToDto(producto));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An issue occurred while obtaining products");
        }
    }

    //Agregar un nuevo producto
    public async Task<ProductoDto> CreateProducto(InsertUpdateProductoDto insertEventDto)
    {
        try
        {
            Producto producto = new()
            {
                Nombre = insertEventDto.Nombre,
                Descripcion = insertEventDto.Descripcion,
                Precio = insertEventDto.Precio,
                EstadoId = insertEventDto.EstadoId,
                FechaCreacion = DateTime.Now
            };

            context.Add(producto);
            await context.SaveChangesAsync();

            ProductoDto productoDto = ProductoDto.ProductosToDto(producto);

            return productoDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An error occurred while creating a product");
        }
    }

    //Actualizar un producto
    public async Task<bool> UpdateProducto(InsertUpdateProductoDto insUpdProductoDto, int id)
    {
        try
        {
            var producto = await context.Productos.FindAsync(id);

            if (producto is null)
            {
                return false;
            }

            producto.Nombre = insUpdProductoDto.Nombre;
            producto.Descripcion = insUpdProductoDto.Descripcion;
            producto.Precio = insUpdProductoDto.Precio;
            producto.EstadoId = insUpdProductoDto.EstadoId;

            await context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception();
        }
    }

    //Eliminar un producto
    public async Task<bool> DeleteProducto(int id)
    {
        try
        {
            var producto = await context.Productos.FindAsync(id);

            if (producto is null)
            {
                return false;
            }

            context.Remove(producto);
            await context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception();
        }
    }

}
