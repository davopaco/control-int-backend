using Microsoft.AspNetCore.Mvc;
using ProductManager.Dtos;
using ProductManager.Services;

namespace ProductManager.Controllers;

[ApiController]
[Route("api/images")]
public class ImagenesController(ImagenesService imagenesService) : ControllerBase
{
    [HttpGet("{id}", Name = "GetImageById")]
    public async Task<IActionResult> GetImagesForProduct(int id)
    {
        try
        {
            var imagenes = await imagenesService.GetAllImagesForProduct(id);

            return Ok(imagenes);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateImage([FromBody] InsertImageDto insertImageDto)
    {
        try
        {
            var productoDto = await imagenesService.CreateImage(insertImageDto);

            return CreatedAtRoute("GetImageById", new { id = productoDto.Id }, productoDto);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        try
        {
            var productoDto = await imagenesService.DeleteImage(id);

            if (!productoDto) return NotFound();

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}
