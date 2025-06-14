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

    
    public IActionResult Index(){
        Juego salaEscape = new Juego();
        salaEscape.inicializarJuego();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape)); 
        return RedirectToAction("Video");
    }
    public IActionResult ValidarCodigo (string codigo,int idSalaAnterior){
        Juego salaEscape =  Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.Escenas[salaEscape.jugador.SalaActual].CodigoCorrecto == codigo){
            string proximaView = salaEscape.obtenerProximaViewEnEscena();
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
        string viewActual = salaEscape.obtenerViewActual();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        ViewBag.viewActual = viewActual;
        return View("Error");
    }
    public IActionResult Video()
    {
        string? juegoString = HttpContext.Session.GetString("salaEscape");
        if (string.IsNullOrEmpty(juegoString))
        {
            return RedirectToAction("Index"); // O redirigir a una vista de error
        }
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        // ViewBag.debug = $"Sala: {salaEscape.jugador.SalaActual}, Video: {salaEscape.obtenerVideoDeEscenaActual()}, View: {salaEscape.obtenerViewActual()}";
        if (!salaEscape.Escenas.ContainsKey(salaEscape.jugador.SalaActual))
        {
            return RedirectToAction("Index"); // o mostrar un mensaje de error amigable
        }
        ViewBag.video = salaEscape.obtenerVideoDeEscenaActual();
        ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();
        salaEscape.avanzarView();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View();
}

}
