namespace ProductManager.Models;

public class ImagenProductos
{
    public int Id { get; set; }
    public int ImagenId { get; set; }
    public Imagen? Imagen { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
}
