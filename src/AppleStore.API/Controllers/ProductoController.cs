using AppleStore.Application.Services;
using AppleStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoService _productoService;

    public ProductoController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _productoService.ObtenerTodos();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _productoService.ObtenerPorId(id);

        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
        await _productoService.Crear(producto);
        return Ok("Producto creado correctamente");
    }

    [HttpPut]
    public IActionResult Update(Producto producto)
    {
        _productoService.Actualizar(producto);
        return Ok("Producto actualizado correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productoService.Eliminar(id);
        return Ok("Producto eliminado correctamente");
    }
}