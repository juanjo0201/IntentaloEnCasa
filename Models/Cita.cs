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
    [Display(Name = "Correo electrónico")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "Escribe un teléfono válido")]
    [Display(Name = "Teléfono")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de la cita")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Selecciona una actividad")]
    [Display(Name = "Actividad")]
    public string ActividadClave { get; set; } = string.Empty;

    public string NombreActividad() =>
        Actividad.Todas.FirstOrDefault(a => a.Clave == ActividadClave)?.Nombre ?? "Sin actividad";

    public decimal Precio() =>
        Actividad.Todas.FirstOrDefault(a => a.Clave == ActividadClave)?.Precio ?? 0;
}