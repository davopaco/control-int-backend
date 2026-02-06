using ProductManager.Models;

namespace ProductManager.Dtos;

public record ProductoDto(int Id, string Nombre, string Descripcion, decimal Precio, int EstadoId)
{
    // Función pipe para obtener una instancia DTO a partir del Producto
    public static ProductoDto ProductosToDto(Producto producto)
    {
        return new ProductoDto(producto.Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.EstadoId);
    }
}
