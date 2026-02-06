using System.ComponentModel.DataAnnotations;

namespace ProductManager.Dtos;

public record InsertUpdateProductoDto([Required] string Nombre, [Required] string Descripcion, [Required] decimal Precio, [Required] int EstadoId);
