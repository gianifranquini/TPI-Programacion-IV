using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

namespace AppleStore.Application.Services;

public class UsuarioService
{
    private readonly IRepository<Usuario> _usuarioRepository;

    public UsuarioService(IRepository<Usuario> usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<Usuario>> GetAll()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario?> GetById(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task Create(Usuario usuario)
    {
        await _usuarioRepository.AddAsync(usuario);
    }
    public void Update(Usuario usuario)
    {
        _usuarioRepository.Update(usuario);
    }
    public async Task Delete(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);

        if (usuario != null)
        {
            _usuarioRepository.Delete(usuario);
        }
    }
}