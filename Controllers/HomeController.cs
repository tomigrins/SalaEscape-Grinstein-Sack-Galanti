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
        salaEscape.inicializarJuego();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape)); 
        return View("Casamiento");
    }
    public IActionResult ValidarCodigo (int codigo,int idSalaAnterior){
        Juego salaEscape =  Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.codigoCorrecto == codigo){
            int proximaView = salaEscape.obtenerProximaSala(idSalaAnterior);
            return RedirectToAction(proximaView);
        }
        else{
            
            return RedirectToAction("Error");
        }
    }
}
