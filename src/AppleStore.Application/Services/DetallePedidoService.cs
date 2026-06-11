using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

namespace AppleStore.Application.Services;

public class DetallePedidoService
{
    private readonly IRepository<DetallePedido> _detalleRepository;

    public DetallePedidoService(IRepository<DetallePedido> detalleRepository)
    {
        _detalleRepository = detalleRepository;
    }

    public async Task<List<DetallePedido>> GetAll()
    {
        return await _detalleRepository.GetAllAsync();
    }

    public async Task<DetallePedido?> GetById(int id)
    {
        return await _detalleRepository.GetByIdAsync(id);
    }

    public async Task Create(DetallePedido detalle)
    {
        await _detalleRepository.AddAsync(detalle);
    }

    public void Update(DetallePedido detalle)
    {
        _detalleRepository.Update(detalle);
    }

    public async Task Delete(int id)
    {
        var detalle = await _detalleRepository.GetByIdAsync(id);

        if (detalle != null)
        {
            _detalleRepository.Delete(detalle);
        }
    }
}