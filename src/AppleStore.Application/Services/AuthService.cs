using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;
using BCrypt.Net;
namespace AppleStore.Application.Services;

public class AuthService
{
    private readonly IRepository<Usuario> _usuarioRepository;

    public AuthService(IRepository<Usuario> usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario?> ValidarUsuario(string nombre, string contrasenia)
    {
        // Busca el usuario por nombre
        var usuarios = await _usuarioRepository.GetAllAsync();

        var usuario = usuarios.FirstOrDefault(u => u.Nombre == nombre);

        // Si no existe, devuelve null
        if (usuario == null)
        {
            return null;
        }

        // Verifica que la contraseña ingresada coincida con el hash almacenado
        bool passwordCorrecta = BCrypt.Net.BCrypt.Verify(
            contrasenia,
            usuario.Contrasenia);

        if (!passwordCorrecta)
        {
            return null;
        }

        return usuario;
    }
}