namespace AppleStore.Application.DTOs;

public class DolarResponse
{
    public decimal Compra { get; set; }

    public decimal Venta { get; set; }

    public string Casa { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Moneda { get; set; } = string.Empty;

    public DateTime FechaActualizacion { get; set; }
}