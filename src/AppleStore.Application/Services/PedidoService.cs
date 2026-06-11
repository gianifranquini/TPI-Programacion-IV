using AppleStore.Application.Interfaces;
using AppleStore.Domain.Entities;

namespace AppleStore.Application.Services;

public class PedidoService
{
    private readonly IRepository<Pedido> _pedidoRepository;

    public PedidoService(IRepository<Pedido> pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<List<Pedido>> GetAll()
    {
        return await _pedidoRepository.GetAllAsync();
    }

    public async Task<Pedido?> GetById(int id)
    {
        return await _pedidoRepository.GetByIdAsync(id);
    }

    public async Task Create(Pedido pedido)
    {
        pedido.Fecha_Creacion = DateTime.Now;
        pedido.Fecha_Actualizacion = DateTime.Now;

        await _pedidoRepository.AddAsync(pedido);
    }
    public void Update(Pedido pedido)
    {
        pedido.Fecha_Actualizacion = DateTime.Now;

        _pedidoRepository.Update(pedido);
    }

    public async Task Delete(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);

        if (pedido != null)
        {
            _pedidoRepository.Delete(pedido);
        }
    }
}