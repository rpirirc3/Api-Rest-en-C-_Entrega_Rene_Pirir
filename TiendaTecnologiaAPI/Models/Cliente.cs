using System.ComponentModel.DataAnnotations;

namespace TiendaTecnologiaAPI.Models;

public class Cliente
{
    public int IdCliente { get; set; }

    [Required]
    [MaxLength(20)]
    public string Nit { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
}
