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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Claves primarias
        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.Id_Usuario);

        modelBuilder.Entity<Producto>()
            .HasKey(p => p.Id_Producto);

        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.Id_Categoria);

        modelBuilder.Entity<Pedido>()
            .HasKey(p => p.Id_Pedido);

        modelBuilder.Entity<DetallePedido>()
            .HasKey(d => d.Id_Detalle_Pedido);

        // Relaciones

        // Categoria -> Productos
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.Id_Categoria);

        // Usuario -> Pedidos
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Pedidos)
            .HasForeignKey(p => p.Id_Usuario);

        // Pedido -> DetallesPedido
        modelBuilder.Entity<DetallePedido>()
            .HasOne(d => d.Pedido)
            .WithMany(p => p.DetallesPedido)
            .HasForeignKey(d => d.Id_Pedido);

        // Producto -> DetallesPedido
        modelBuilder.Entity<DetallePedido>()
            .HasOne(d => d.Producto)
            .WithMany(p => p.DetallesPedido)
            .HasForeignKey(d => d.Id_Producto);

        // Configuración de decimales
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Producto>()
            .Property(p => p.Peso)
            .HasPrecision(18, 2);

        modelBuilder.Entity<DetallePedido>()
            .Property(d => d.Precio_Unitario)
            .HasPrecision(18, 2);

        modelBuilder.Entity<DetallePedido>()
            .Property(d => d.Subtotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<DetallePedido>()
            .Property(d => d.Descuento)
            .HasPrecision(18, 2);
    }
}