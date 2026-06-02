namespace AppleStore.Domain.Entities;

public class Producto
{
    public int Id_Producto { get; set; }

    public int Id_Categoria { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public decimal Peso { get; set; }

    public string Imagen { get; set; } = string.Empty;

    public bool Destacado { get; set; }

    public bool Activo { get; set; }
}