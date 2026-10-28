using System.ComponentModel.DataAnnotations;

namespace IntentaloEnCasa.Models;

public class Cita
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Escribe un correo válido")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "Escribe un teléfono válido")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha es obligatoria")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Selecciona una actividad")]
    public string ActividadClave { get; set; } = string.Empty;

    // Igual que en JS: métodos que consultan el catálogo
    public string NombreActividad() =>
        Actividad.Todas.FirstOrDefault(a => a.Clave == ActividadClave)?.Nombre ?? "Sin actividad";

    public decimal Precio() =>
        Actividad.Todas.FirstOrDefault(a => a.Clave == ActividadClave)?.Precio ?? 0;
}