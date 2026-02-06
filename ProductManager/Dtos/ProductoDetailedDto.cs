using ProductManager.Models;

namespace ProductManager.Dtos;

public record ProductoDetailedDto(int Id, string Nombre, string Descripcion, decimal Precio, string Estado, int EstadoId)
{
    // Función pipe para obtener una instancia DTO a partir del Producto
    public static ProductoDetailedDto ProductosToDto(Producto producto)
    {
        return new ProductoDetailedDto(producto.Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Estado!.Nombre, producto.Estado!.Id);
    }
}
