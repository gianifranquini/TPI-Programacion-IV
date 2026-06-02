namespace AppleStore.Domain.Entities;

using AppleStore.Domain.Enums;

public class Pedido
{
    public int Id_Pedido { get; set; }

    public int Id_Usuario { get; set; }

    public EstadoPedido Estado { get; set; }

    public DateTime Fecha_Creacion { get; set; }

    public DateTime Fecha_Actualizacion { get; set; }
}