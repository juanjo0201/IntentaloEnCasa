using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IntentaloEnCasa.Models;

namespace IntentaloEnCasa.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // El controlador toma los datos del modelo y se los pasa a la vista
        return View(Actividad.Todas);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}