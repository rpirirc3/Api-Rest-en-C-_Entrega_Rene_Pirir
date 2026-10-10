using System.ComponentModel.DataAnnotations;

namespace TiendaTecnologiaAPI.Models;

public class Marca
{
    public int IdMarca { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
}
