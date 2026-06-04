namespace AppleStore.Domain.Entities;

using AppleStore.Domain.Enums;

public class Usuario
{
    public int Id_Usuario { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Contrasenia { get; set; } = string.Empty;

    public Rol Rol { get; set; }

    public ICollection<Pedido> Pedidos { get; set; }
        = new List<Pedido>();
}