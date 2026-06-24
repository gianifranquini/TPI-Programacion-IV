using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

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
        var usuarios = await _usuarioRepository.GetAllAsync();

        return usuarios.FirstOrDefault(u =>
            u.Nombre == nombre &&
            u.Contrasenia == contrasenia);
    }
}