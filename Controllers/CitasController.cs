using Microsoft.AspNetCore.Mvc;
using IntentaloEnCasa.Models;

namespace IntentaloEnCasa.Controllers;

public class CitasController : Controller
{
    // Nuestra "base de datos": una lista en memoria (equivale al arreglo citas de JS)
    private static readonly List<Cita> citas = new();
    private static int siguienteId = 1;

    // GET: /Citas  -> muestra el formulario vacío
    [HttpGet]
    public IActionResult Index()
    {
        return View(new Cita());
    }

    // POST: /Citas -> recibe el formulario
    [HttpPost]
    public IActionResult Index(Cita cita)
    {
        // Reglas extra que las anotaciones no cubren
        if (!Actividad.Todas.Any(a => a.Clave == cita.ActividadClave))
        {
            ModelState.AddModelError(nameof(cita.ActividadClave), "Selecciona una actividad válida");
        }

        if (cita.Fecha.Date < DateTime.Today)
        {
            ModelState.AddModelError(nameof(cita.Fecha), "La fecha no puede ser anterior a hoy");
        }

        if (!ModelState.IsValid)
        {
            return View(cita); // vuelve al formulario con los errores y lo que escribió
        }

        cita.Id = siguienteId++;
        citas.Add(cita);

        return RedirectToAction(nameof(Resultado), new { id = cita.Id });
    }

    // GET: /Citas/Resultado/1 -> confirmación
    [HttpGet]
    public IActionResult Resultado(int id)
    {
        var cita = citas.FirstOrDefault(c => c.Id == id);
        if (cita == null)
        {
            return NotFound();
        }
        return View(cita);
    }

    // GET: /Citas/Lista -> todas las citas con el total
    [HttpGet]
    public IActionResult Lista()
    {
        ViewBag.Total = citas.Sum(c => c.Precio());
        return View(citas);
    }
}