using System.ComponentModel.DataAnnotations;

namespace TiendaTecnologiaAPI.Models;

public class Producto
{
    public int IdProducto { get; set; }

    public int IdMarca { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(0, 9999999)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
