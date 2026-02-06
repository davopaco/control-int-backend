using Microsoft.AspNetCore.Mvc;

namespace ProductManager.Services
{
    [Route("api/statuses")]
    [ApiController]
    public class EstadosController(EstadosService estadosService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEstados()
        {
            try
            {
                var estados = await estadosService.GetAllEstados();
                return Ok(estados);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
