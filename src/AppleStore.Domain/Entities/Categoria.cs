namespace AppleStore.Domain.Entities;

public class Categoria
{
    public int Id_Categoria { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public ICollection<Producto> Productos { get; set; }
        = new List<Producto>();
}