using Microsoft.EntityFrameworkCore;
using ProductManager.Dtos;
using ProductManager.Models;

namespace ProductManager.Services;

public class ImagenesService(ProductManagerContext context)
{
    //Obtener todas las imágenes
    public async Task<List<ImagenDto>> GetAllImagesForProduct(int id)
    {
        try
        {
            return await context.ImagenesProductos.Where(imagenP => imagenP.ProductoId == id).Include(imagenP => imagenP.Imagen).Select(imagen => new ImagenDto(imagen.Imagen!.Id, imagen.Imagen.Content)).AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An issue occurred while obtaining products");
        }
    }

    //Agregar una nueva imagen para un producto
    public async Task<ImagenDto> CreateImage(InsertImageDto insertImageDto)
    {
        try
        {

            Imagen imagen = new()
            {
                Content = insertImageDto.Content
            };

            ImagenProductos imagenProductos = new()
            {
                Imagen = imagen,
                ProductoId = insertImageDto.ProductId
            };

            context.Add(imagen);
            context.Add(imagenProductos);
            await context.SaveChangesAsync();

            return new ImagenDto(imagen.Id, imagen.Content);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An error occurred while creating a product");
        }
    }

    //Eliminar una imagen
    public async Task<bool> DeleteImage(int id)
    {
        try
        {
            var imagen = await context.Imagenes.FindAsync(id);

            if (imagen is null)
            {
                return false;
            }

            context.Remove(imagen);
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
