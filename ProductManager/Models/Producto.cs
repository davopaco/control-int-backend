namespace ProductManager.Models;

public class Producto
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int EstadoId { get; set; }
    public Estado? Estado { get; set; }
}
