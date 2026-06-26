using AppleStore.Application.Services;
using AppleStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetallePedidoController : ControllerBase
{
    private readonly DetallePedidoService _detalleService;

    public DetallePedidoController(DetallePedidoService detalleService)
    {
        _detalleService = detalleService;
    }

    // GET todos
    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _detalleService.GetAll();
        return Ok(lista);
    }

    // GET por id
    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _detalleService.GetById(id);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    // POST crear
    [Authorize(Roles = "Admin,Cliente")]
    [HttpPost]
    public async Task<IActionResult> Create(DetallePedido detalle)
    {
        await _detalleService.Create(detalle);
        return Ok("Detalle de pedido creado");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public IActionResult Update(DetallePedido detalle)
    {
        _detalleService.Update(detalle);
        return Ok("Detalle de pedido actualizado");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _detalleService.Delete(id);
        return Ok("Detalle de pedido eliminado");
    }
}