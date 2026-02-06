using Microsoft.AspNetCore.Mvc;
using ProductManager.Dtos;
using ProductManager.Services;

namespace ProductManager.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    [HttpGet("sorted")]
    public async Task<IActionResult> GetAllProductsSorted()
    {
        try
        {
            var productos = await productsService.GetAllProductosSorted();
            return Ok(productos);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductos()
    {
        try
        {
            var productos = await productsService.GetAllProductos();
            return Ok(productos);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}", Name = "GetProdById")]
    public async Task<IActionResult> GetProductoById(int id)
    {
        try
        {
            var information = await productsService.GetProductoById(id);

            if (information.Warning)
            {
                return NotFound();
            }

            return Ok(information.Content);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProducto([FromBody] InsertUpdateProductoDto insertUpdateProductoDto)
    {
        try
        {
            var productoDto = await productsService.CreateProducto(insertUpdateProductoDto);

            return CreatedAtRoute("GetProdById", new { id = productoDto.Id }, productoDto);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto([FromBody] InsertUpdateProductoDto insertUpdateProductoDto, int id)
    {
        try
        {
            var productoDto = await productsService.UpdateProducto(insertUpdateProductoDto, id);

            if (!productoDto) return NotFound();

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        try
        {
            var productoDto = await productsService.DeleteProducto(id);

            if (!productoDto) return NotFound();

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}
