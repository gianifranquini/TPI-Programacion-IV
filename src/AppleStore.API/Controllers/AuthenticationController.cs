using AppleStore.Application.DTOs;
using AppleStore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppleStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthenticationController(
        AuthService authService,
        IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // Validamos usuario y contraseña
        var usuario = await _authService.ValidarUsuario(
            request.Nombre,
            request.Contrasenia);

        if (usuario == null)
        {
            return Unauthorized("Usuario o contraseña incorrectos");
        }

        // Datos que viajarán dentro del token
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.Role, usuario.Rol.ToString())
        };

        // Clave secreta utilizada para firmar el token
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        // Creación del token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials);

        var tokenString =
            new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new
        {
            Token = tokenString
        });
    }
}