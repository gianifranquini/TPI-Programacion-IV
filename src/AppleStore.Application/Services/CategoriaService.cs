using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

namespace AppleStore.Application.Services;

public class CategoriaService
{
    private readonly IRepository<Categoria> _categoriaRepository;

    public CategoriaService(IRepository<Categoria> categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<List<Categoria>> GetAll()
    {
        return await _categoriaRepository.GetAllAsync();
    }

    public async Task<Categoria?> GetById(int id)
    {
        return await _categoriaRepository.GetByIdAsync(id);
    }

    public async Task Create(Categoria categoria)
    {
        await _categoriaRepository.AddAsync(categoria);
    }
    public void Update(Categoria categoria)
    {
        _categoriaRepository.Update(categoria);
    }

    public async Task Delete(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);

        if (categoria != null)
        {
            _categoriaRepository.Delete(categoria);
        }
    }
}