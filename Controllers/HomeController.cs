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
    public IActionResult Error()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        ViewBag.h1 = "El código ingresado no es correcto.";
        ViewBag.h2 = "Presione el botón para volver a la sala";
        ViewBag.boton = "Volver";
        string viewActual = salaEscape.obtenerViewActual();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        ViewBag.viewActual = viewActual;
        return View("Mensaje");
    }
    // public IActionResult Video()
    // {
    //     // string? juegoString = HttpContext.Session.GetString("salaEscape");
    //     // if (string.IsNullOrEmpty(juegoString))
    //     // {
    //     //     return RedirectToAction("Index"); // O redirigir a una vista de error
    //     // }
    //     // Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
    //     // if (!salaEscape.Escenas.ContainsKey(salaEscape.jugador.SalaActual))
    //     // {
    //     //     return RedirectToAction("Index");
    //     // }
    //     // ViewBag.debug = "paso por el controller de video!!";
    //     // ViewBag.video = salaEscape.obtenerVideoDeEscenaActual();
    //     // ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();
    //     // salaEscape.avanzarView();
    //     // HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
    //     // return View();  
    //     string? juegoString = HttpContext.Session.GetString("salaEscape");

    //     //DEBUGGERS
    //     if (string.IsNullOrEmpty(juegoString))
    //     {
    //         ViewBag.debug = "NO HAY juego en sesión (juegoString es null)";
    //         return View("Index");
    //     }
    //     Juego? salaEscape = Objetos.StringToObject<Juego>(juegoString);
    //     if (string.IsNullOrEmpty(juegoString))
    //     {
    //         ViewBag.debug = "salaEscape no existe en sesión";
    //         return View("Index");
    //     }
    //     else
    //     {
    //         ViewBag.debug = $"JSON recuperado: {juegoString}";
    //     }

    //     if (salaEscape == null)
    //     {
    //         ViewBag.debug = "ERROR: No se pudo deserializar salaEscape";
    //         return View("Index");
    //     }
    //     if (salaEscape.Escenas == null)
    //     {
    //         ViewBag.debug = "ERROR: salaEscape.Escenas es null";
    //         return View("Index");
    //     }


    //     if (salaEscape.jugador == null)
    //     {
    //         ViewBag.debug = "ERROR: salaEscape.jugador es null";
    //         return View("Index");
    //     }
    //     if (!salaEscape.Escenas.ContainsKey(salaEscape.jugador.SalaActual))
    //     {
    //         ViewBag.debug = $"ERROR: Escenas no contiene la clave {salaEscape.jugador.SalaActual}";
    //         return View("Index");
    //     }

    //     ViewBag.video = salaEscape.obtenerVideoDeEscenaActual();
    //     ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();
    //     salaEscape.avanzarView();
    //     HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
    //     return View();
    // }
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
            return RedirectToAction("Index");
        }

        ViewBag.video = viewActual.VideoId;
        ViewBag.segundoDeCorte = viewActual.SegundoDeCorte;
        ViewBag.proximaView = salaEscape.obtenerProximaViewEnEscena();

        salaEscape.avanzarView();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));

        return View();
    }

    // public IActionResult BañoCasamiento()
    // {
    //     Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
    //     ViewBag.h1 = "Tenés ganas de ir al baño";
    //     ViewBag.h2 = "Estás en un casamiento. La música suena lejana, la pista de baile vibra, pero algo te incomoda. Esa sensación ineludible... te dan ganas de ir al baño. Sentís una presencia extraña en el ambiente, como si no fueras la única en apurarte a salir de ahí. Presioná el botón si te animás a continuar.";
    //     ViewBag.boton = "Ir al baño";
    //     string viewActual = salaEscape.obtenerViewActual();
    //     HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
    //     ViewBag.viewActual = viewActual;
    //     salaEscape.avanzarView();
    //     return View("Mensaje");
    // }
    public IActionResult Mensaje()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();

        ViewBag.h1 = viewActual.Titulo;
        ViewBag.h2 = viewActual.Texto;
        ViewBag.boton = viewActual.BotonTexto;
        ViewBag.viewActual = viewActual.Tipo;
        ViewBag.proximaAccion = viewActual.ProximaAccion;

        salaEscape.avanzarView();
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View("Mensaje");
    }

}
