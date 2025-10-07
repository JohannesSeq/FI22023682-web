using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CalculadoraBinaria.Models;

namespace CalculadoraBinaria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //Controlador encargado de llamar el index la primera vez que se ejecuta mediante un get
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    //Cuando se ejecuta el index por medio de un post, se ejecuta la accion de abajo, que manda a llamar el metodo en el modelo encargado de realizar toda la logica de negocio.
    public IActionResult Index(binarioModel binarioModel)
    {

        binarioModel.ejecucion();
        return View(binarioModel);

    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
