using System.ComponentModel.DataAnnotations;

namespace IntentaloEnCasa.Models;

public class Actividad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(0, 100000, ErrorMessage = "Ingresa un precio válido")]
    public int Precio { get; set; }

    [Display(Name = "Incluye equipo")]
    public bool IncluyeEquipo { get; set; }

    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}