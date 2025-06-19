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


    public IActionResult Inicio()
    {
        Juego salaEscape = new Juego();
        salaEscape.inicializarJuego();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return RedirectToAction("Video");
    }
    public IActionResult ValidarCodigo(string codigo, int idSalaAnterior)
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.Escenas[salaEscape.jugador.SalaActual].CodigoCorrecto == codigo)
        {
            string proximaView = salaEscape.obtenerProximaViewEnEscena();
            return View("Sala" + proximaView);
        }
        else
        {
            ViewBag.SalaActual = salaEscape.obtenerViewParaError();
            return RedirectToAction("Error");
        }
    }
    public IActionResult Video()
    {
        string? juegoString = HttpContext.Session.GetString("salaEscape");

        if (string.IsNullOrEmpty(juegoString))
        {
            ViewBag.debug = "NO HAY juego en sesión";
            return View("Index");
        }

        Juego salaEscape = Objetos.StringToObject<Juego>(juegoString);

        View viewActual = salaEscape.obtenerViewActualObjeto();

        if (viewActual == null || viewActual.Tipo != "Video")
        {
            ViewBag.debug = "La view actual no es de tipo Video.";
            return View("Index");
        }

        ViewBag.video = viewActual.VideoId;
        ViewBag.segundoDeCorte = viewActual.SegundoDeCorte;
        ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();

        salaEscape.avanzarView();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));

        return View();
    }

    public IActionResult Mensaje()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();

        ViewBag.h1 = viewActual.Titulo;
        ViewBag.h2 = viewActual.Texto;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.viewActual = viewActual.Tipo;
        ViewBag.proximaAccion = viewActual.ProximaAccion;
        ViewBag.claseMensaje = viewActual.claseMensaje;

        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View();
    }
    public IActionResult Continuar(){
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        salaEscape.avanzarView();

        string tipo = salaEscape.obtenerTipoViewActual();

        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        switch (tipo)
        {
            case "Video":
                return RedirectToAction("Video");
            case "Mensaje":
                return RedirectToAction("Mensaje");
            case "Juego":
                return RedirectToAction("Juego");
            default:
                ViewBag.debug = "No se encontró el tipo de la view";
                return View("Index");
        }
    }
    public IActionResult Juego(){
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        if (viewActual == null || viewActual.Tipo != "Juego")
        {
            ViewBag.debug = "La view actual no es de tipo Juego.";
            return View("Index");
        }
        string nombreJuego = viewActual.nombreJuego;
        return View(nombreJuego);
    }
}
