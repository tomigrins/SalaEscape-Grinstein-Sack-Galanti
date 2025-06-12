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
    public IActionResult ValidarCodigo (string codigo,int idSalaAnterior){
        Juego salaEscape =  Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.Escenas[salaEscape.jugador.SalaActual].CodigoCorrecto == codigo){
            string proximaView = salaEscape.obtenerProximaSala();
            return View("Sala" + proximaView);
        }
        else{
            ViewBag.SalaActual=salaEscape.obtenerViewParaError();
            return RedirectToAction("Error");
        } 
    }
    public IActionResult Error(){
        Juego salaEscape =  Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.h1 = "El código ingresado no es correcto.";
        ViewBag.h2 = "Presione el botón para volver a la sala";
        ViewBag.boton = "Volver";
        ViewBag.proxSala = salaEscape.obtenerProximaSala();
        return View("Error");
    }
    public IActionResult Video(){
    Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
    ViewBag.video = salaEscape.obtenerEscenaActual().Video;
    ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena(); // esto es clave
    return View();
}

}
