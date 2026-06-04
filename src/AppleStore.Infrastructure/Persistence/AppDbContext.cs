using AppleStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Producto> Productos => Set<Producto>();

    public DbSet<Categoria> Categorias => Set<Categoria>();

    public DbSet<Pedido> Pedidos => Set<Pedido>();

    public DbSet<DetallePedido> DetallesPedido => Set<DetallePedido>();
}