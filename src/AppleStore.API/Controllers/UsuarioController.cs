using AppleStore.Application.Services;
using AppleStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _usuarioService.GetAll());
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetById(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        await _usuarioService.Create(usuario);
        return Ok("Usuario creado");
    }

    [HttpPut]
    public IActionResult Update(Usuario usuario)
    {
        _usuarioService.Update(usuario);
        return Ok("Usuario actualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.Delete(id);
        return Ok("Usuario eliminado");
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(Usuario usuario)
    {
        // 1. forzar rol cliente por seguridad
        usuario.Rol = AppleStore.Domain.Enums.Rol.Cliente;

        // 2. hashear contraseña antes de guardar
        usuario.Contrasenia =
            BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenia);

        // 3. guardar
        await _usuarioService.Create(usuario);

        return Ok("Usuario registrado");
    }
}
