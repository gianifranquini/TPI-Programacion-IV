using AppleStore.Application.Services;
using AppleStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    // GET todos los pedidos
    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _pedidoService.GetAll();
        return Ok(pedidos);
    }

    // GET por ID
    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _pedidoService.GetById(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    // POST crear pedido
    [Authorize(Roles = "Admin,Cliente")]
    [HttpPost]
    public async Task<IActionResult> Create(Pedido pedido)
    {
        await _pedidoService.Create(pedido);
        return Ok("Pedido creado");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public IActionResult Update(Pedido pedido)
    {
        _pedidoService.Update(pedido);
        return Ok("Pedido actualizado");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _pedidoService.Delete(id);
        return Ok("Pedido eliminado");
    }
}