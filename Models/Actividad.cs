namespace IntentaloEnCasa.Models;

public class Actividad
{
    public string Clave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public bool IncluyeEquipo { get; set; }

    // "Base de datos" en memoria: el catálogo de actividades
    public static readonly List<Actividad> Todas = new()
    {
        new Actividad { Clave = "bongee",   Nombre = "Bongee",            Precio = 70, IncluyeEquipo = true },
        new Actividad { Clave = "canopy",   Nombre = "Canopy",            Precio = 40, IncluyeEquipo = true },
        new Actividad { Clave = "escalada", Nombre = "Escalada en roca",  Precio = 30, IncluyeEquipo = true },
        new Actividad { Clave = "rally",    Nombre = "Rally de go-karts", Precio = 25, IncluyeEquipo = true },
        new Actividad { Clave = "tubing",   Nombre = "Tubing",            Precio = 30, IncluyeEquipo = true },
    };
}