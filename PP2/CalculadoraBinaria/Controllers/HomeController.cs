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

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
        public IActionResult Index( binarioModel binarioModel )
    {
        //string v_a = "";
        //string V_b = "";

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
