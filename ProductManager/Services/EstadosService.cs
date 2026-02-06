using Microsoft.EntityFrameworkCore;
using ProductManager.Dtos;

namespace ProductManager.Services;

public class EstadosService(ProductManagerContext context)
{
    //Obtener todos los estados
    public async Task<List<EstadoDto>> GetAllEstados()
    {
        try
        {
            return await context.Estado.Select(estado => new EstadoDto(estado.Id, estado.Nombre)).AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An issue occurred while obtaining products");
        }
    }
}
