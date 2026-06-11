using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

namespace AppleStore.Application.Services;

public class ProductoService
{
    private readonly IRepository<Producto> _productoRepository;

    public ProductoService(IRepository<Producto> productoRepository)
    {
        _productoRepository = productoRepository;
    }

    // Traer todos los productos
    public async Task<List<Producto>> ObtenerTodos()
    {
        return await _productoRepository.GetAllAsync();
    }

    // Traer un producto por id
    public async Task<Producto?> ObtenerPorId(int id)
    {
        return await _productoRepository.GetByIdAsync(id);
    }

    // Crear producto
    public async Task Crear(Producto producto)
    {
        await _productoRepository.AddAsync(producto);
    }

    // Actualizar producto
    public void Actualizar(Producto producto)
    {
        _productoRepository.Update(producto);
    }

    // Eliminar producto
    public async Task Eliminar(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);

        if (producto != null)
        {
            _productoRepository.Delete(producto);
        }
    }
}