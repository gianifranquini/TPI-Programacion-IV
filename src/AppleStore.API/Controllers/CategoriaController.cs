using AppleStore.Application.Services;
using AppleStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService _categoriaService;

    public CategoriaController(CategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAll();
        return Ok(categorias);
    }

    [Authorize(Roles = "Admin,Cliente")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaService.GetById(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(Categoria categoria)
    {
        await _categoriaService.Create(categoria);
        return Ok("Categoria creada");
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public IActionResult Update(Categoria categoria)
    {
        _categoriaService.Update(categoria);
        return Ok("Categoria actualizada");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoriaService.Delete(id);
        return Ok("Categoria eliminada");
    }
}