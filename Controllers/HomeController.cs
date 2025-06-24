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
                View viewActual = salaEscape.obtenerViewActualObjeto();
                string juegoEspecifico = viewActual.nombreJuego;
                return RedirectToAction(juegoEspecifico);
            default:
                ViewBag.debug = "No se encontró el tipo de la view";
                return View("Index");
        }
    }
    public IActionResult Memotest()
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();
        if (viewActual == null || viewActual.Tipo != "Juego")
        {
            ViewBag.debug = "La view actual no es de tipo Juego.";
            return View("Index");
        }
        string nombreJuego = viewActual.nombreJuego;
        ViewBag.cartas = viewActual.Memotest["Cartas"];
        ViewBag.paresEspeciales = viewActual.Memotest["Pares especiales"];
        ViewBag.letrasReveladas = viewActual.Memotest["Letras reveladas"];
        ViewBag.CodigoIngresado = viewActual.Memotest["CodigoIngresado"];
        ViewBag.JuegoFinalizado = viewActual.Memotest["JuegoFinalizado"];
        ViewBag.Gano = viewActual.Memotest["Gano"];
        ViewBag.proximaView = viewActual.ProximaAccion;
        ViewBag.titulo0 = "Carta de la bruja";
        ViewBag.mensaje0 = @"El espejo se quiebra con un <span style=""color:red;"">R</span>uido seco.<br>
                        No hay nadie, pero un <span style=""color:red;"">O</span>jo se abre en la sombra.<br>
                        Te observa. Te estudia. Susurra con voz <span style=""color:red;"">E</span>terna:<br>
                        “<span style=""color:red;"">M</span>irá lo que no querés ver”.<br>
                        Una <span style=""color:red;"">B</span>risa te envuelve.<br>
                        No es viento. Es <span style=""color:red;"">R</span>ezo. Es <span style=""color:red;"">U</span>n conjuro.";
        ViewBag.titulo1 = "Carta del inodoro";
        ViewBag.titulo9 = "Carta de la montaña rusa";
        ViewBag.mensaje1 = @"Te sentás, el eco <span style=""color:red;"">I</span>nmóvil del silencio<br>
                        te envuelve en el <span style=""color:red;"">N</span>eblina de lo impensado.<br>
                        El agua cae, un <span style=""color:red;"">O</span>scuro gorgoteo te responde.<br>
                        Algo se mueve <span style=""color:red;"">D</span>entro, no es solo tu reflejo.<br>
                        Un susurro grita: “<span style=""color:red;"">O</span>lvidá salir... si podés.”";
        ViewBag.mensaje9 = @"Subís. Pero no hay rieles. No hay fin.<br>
                        Solo un <span style=""color:red;"">J</span>adeo que crece con el viento.<br>
                        Tu cuerpo no pesa, tu mente no calla.<br>
                        Gritás. Y nadie responde, salvo el <span style=""color:red;"">A</span>ullido.<br>
                        Un <span style=""color:red;"">D</span>estello te ciega.<br>
                        Al abrir los ojos, hay <span style=""color:red;"">O</span>tros ojos. No son tuyos.";
        HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
        return View(nombreJuego);
    }
    public IActionResult MensajeDeParEspecial(int i)
    {
        switch (i)
        {
            case 1:
                ViewBag.h2 = @"
                Te sentás, el eco <span style=""color:red;"">I</span>nmóvil del silencio  
                te envuelve en el <span style=""color:red;"">N</span>eblina de lo impensado.  
                El agua cae, un <span style=""color:red;"">O</span>scuro gorgoteo te responde.  
                Algo se mueve <span style=""color:red;"">D</span>entro, no es solo tu reflejo.  
                Un susurro grita: “<span style=""color:red;"">O</span>lvidá salir... si podés.”
                ";
                ViewBag.h1 = "Carta de inodoro";
                ViewBag.boton = "Verificar y seguir jugando";
                ViewBag.claseMensaje = "Memotest";
                ViewBag.proximaAccion = "ValidarParteCodigo";
                break;
            case 0:
                ViewBag.h2 = @"El espejo se quiebra con un <span style=""color:red;"">R</span>uido seco.  
                No hay nadie, pero un <span style=""color:red;"">O</span>jo se abre en la sombra.  
                Te observa. Te estudia. Susurra con voz <span style=""color:red;"">E</span>terna:  
                “<span style=""color:red;"">M</span>irá lo que no querés ver”.  
                Una <span style=""color:red;"">B</span>risa te envuelve.  
                No es viento. Es <span style=""color:red;"">R</span>ezo. Es <span style=""color:red;"">U</span>n conjuro.";
                ViewBag.h1 = "Carta de la bruja";
                ViewBag.boton = "Verificar y seguir jugando";
                ViewBag.claseMensaje = "Memotest";
                ViewBag.proximaAccion = "ValidarParteCodigo";
                break;
            case 9:
                ViewBag.h2 = @"Subís. Pero no hay rieles. No hay fin.  
                Solo un <span style=""color:red;"">J</span>adeo que crece con el viento.  
                Tu cuerpo no pesa, tu mente no calla.  
                Gritás. Y nadie responde, salvo el <span style=""color:red;"">A</span>ullido.  
                Un <span style=""color:red;"">D</span>estello te ciega.  
                Al abrir los ojos, hay <span style=""color:red;"">O</span>tros ojos. No son tuyos.";
                ViewBag.h1 = "Carta de la montaña rusa";
                ViewBag.boton = "Verificar y seguir jugando";
                ViewBag.claseMensaje = "Memotest";
                ViewBag.proximaAccion = "ValidarParteCodigo";
                break;
            default:
                ViewBag.debug = "El par de cartas no está en la lista de cartas con mensaje de par especial";
                return View("Index");
        }
        ViewBag.indice = i;
        return View("ingresoClave");
    }
    public IActionResult ValidarParteCodigo(int i, string codigo)
    {
        Juego salaEscape = Objetos.StringToObject<Juego>(HttpContext.Session.GetString("salaEscape"));
        View viewActual = salaEscape.obtenerViewActualObjeto();

        if (viewActual?.Memotest == null) return View("Index");

        Dictionary<int, string> partesCorrectas = (Dictionary<int, string>)viewActual.Memotest["PartesCodigo"];
        Dictionary<int, bool> partesValidadas = (Dictionary<int, bool>)viewActual.Memotest["PartesValidadas"];

        if (partesCorrectas.ContainsKey(i) && codigo.ToUpper() == partesCorrectas[i].ToUpper())
        {
            partesValidadas[i] = true;
            HttpContext.Session.SetString("salaEscape", Objetos.ObjectToString(salaEscape));
            return RedirectToAction("Memotest");
        }
        else
        {
            ViewBag.error = "El código es incorrecto. Intentá de nuevo.";
            return RedirectToAction("MensajeDeParEspecial", new { i });
        }
    }

}
