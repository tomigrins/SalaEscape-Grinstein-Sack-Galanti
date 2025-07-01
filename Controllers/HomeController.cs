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
        salaEscape.jugador.numViewActual = -1;
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return RedirectToAction("Continuar");
    }
    public IActionResult ValidarCodigo(string codigo)
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        if (salaEscape.jugador.SalaActual != 4)
        {
            bool igual = salaEscape.obtenerEscenaActual().IgualarCodigo(codigo.ToUpper());
            if (igual)
            {
                HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
                return RedirectToAction("Continuar");
            }
            else
            {
                View viewActual = salaEscape.obtenerViewActualObjeto();
                ViewBag.h1 = viewActual.Titulo;
                ViewBag.error = "El código ingresado no es correcto";
                ViewBag.h2 = viewActual.Texto;
                ViewBag.boton = viewActual.BotonTexto;
                ViewBag.ClaseMensaje = viewActual.claseMensaje;
                HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
                return View("ingresoClave");
            }
        }
        else
        {
            if (codigo == "1" || codigo == "2" || codigo == "3")
            {
                if (codigo == "1" || codigo == "2")
                {
                    salaEscape.jugador.SalaActual = 5;
                    salaEscape.jugador.numViewActual = -1;
                    salaEscape.Escenas.Remove(6);
                    HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
                    return RedirectToAction("Continuar");
                }
                else
                {
                    salaEscape.jugador.SalaActual = 6;
                    salaEscape.jugador.numViewActual = -1;
                    salaEscape.Escenas.Remove(5);
                    HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
                    return RedirectToAction("Continuar");
                }
            }
            else
            {
                View viewActual = salaEscape.obtenerViewActualObjeto();
                ViewBag.h1 = viewActual.Titulo;
                ViewBag.error = "El código ingresado no es correcto";
                ViewBag.h2 = viewActual.Texto;
                ViewBag.boton = viewActual.BotonTexto;
                ViewBag.ClaseMensaje = viewActual.claseMensaje;
                HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
                return View("ingresoClave");
            }
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
        ViewBag.inicioVideo = viewActual.inicioVideo;
        ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();
        

        salaEscape.avanzarView();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View();
    }
    public IActionResult VolverALaViewAnterior()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        salaEscape.jugador.numViewActual = salaEscape.jugador.numViewActual - 2;
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return RedirectToAction("Continuar");
    }

    public IActionResult Mensaje()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        ViewBag.h1 = viewActual.Titulo;
        ViewBag.h2 = viewActual.Texto;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.claseMensaje = viewActual.claseMensaje;

        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View();
    }
    public IActionResult Continuar()
    {
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
            case "IngresoClave":
                return RedirectToAction("IngresoClave");
            case "Inicio":
                View viewActual = salaEscape.obtenerViewActualObjeto();
                ViewBag.h1 = viewActual.Titulo;
                ViewBag.h2 = viewActual.Texto;
                ViewBag.boton = viewActual.BotonTexto;
                ViewBag.claseMensaje = viewActual.claseMensaje;
                return View("Inicio");
            case "Creditos":
                return View("Creditos");
            default:
                ViewBag.debug = "No se encontró el tipo de la view";
                return View("Index");
        }
    }
    public IActionResult Juego()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        return RedirectToAction(viewActual.tipoJuego);
    }
    public IActionResult Genially()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        ViewBag.urlJuego = viewActual.urlJuego;
        ViewBag.boton = viewActual.BotonTexto;
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View("JuegoGenially");
    }
    public IActionResult Mapas()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        ViewBag.mapas = viewActual.listaParaJuego;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.p = viewActual.Texto;
        ViewBag.h1 = viewActual.Titulo;
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View("JuegoMapas");
    }
    public IActionResult BuscandoANemo()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        ViewBag.texto = viewActual.Texto;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.opciones = viewActual.listaParaJuego;
        ViewBag.video = viewActual.VideoId;
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View("JuegoNemo");
    }

    public IActionResult IngresoClave()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        ViewBag.h1 = viewActual.Titulo;
        ViewBag.h2 = viewActual.Texto;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.ClaseMensaje = viewActual.claseMensaje;
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VolverAJugar(){
        return RedirectToAction("Inicio");
    }
}
