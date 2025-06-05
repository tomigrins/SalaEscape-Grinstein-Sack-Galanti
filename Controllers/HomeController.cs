using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaEscape_Grinstein_Sack_Galanti.Models;

namespace SalaEscape_Grinstein_Sack_Galanti.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Inicio(){
        Juego salaEscape = new Juego();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape)); //Ver homeController
        return View("Casamineto");
    }
    public IActionResult ValidarCodigo (int codigo){
        ViewBag. Users = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.codigoCorrecto == codigo){

        }
        //Ver error. DALEEEE FLOR, MUCHAS OLIMPIADAS POCA PROGRAMACION. A LABURAR. PD: Galanti hizo un 1% de esto. Tmp que fuera tanto KKKKK
    }
}
