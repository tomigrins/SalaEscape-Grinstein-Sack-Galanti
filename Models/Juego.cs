using Newtonsoft.Json;
public class Juego
{
    public Dictionary<int, Escena> Escenas { get; set; }
    public Jugador jugador { get; set; }

    public void inicializarJuego()
    {
        Escenas = new Dictionary<int, Escena> {
            {
                0, new Escena(0, "Casamiento", new List<View> {
                    new View("Video", "ardtvdR28SQ", 30, null, null, "Mensaje"),
                    new View("Mensaje", null,null, "Estás en un casamiento. La música suena lejana, la pista de baile vibra, pero algo te incomoda. Esa sensación ineludible... te dan ganas de ir al baño. Sentís una presencia extraña en el ambiente, como si no fueras la única en apurarte a salir de ahí. Presioná el botón si te animás a continuar.", "Ir al baño", "Video", "Te dan ganas de ir al baño", "Baño"),
                    new View("Video", "wpHC614ZHMY", 20, null, null, "Mensaje"),
                    new View("Mensaje", null, null, "Te sentás a descansar y sacás el celular. Abrís un jueguito para pasar el rato… pero algo no cierra. Los colores cambian, los sonidos se distorsionan. Las reglas del juego parecen inventarse solas. Tu reflejo en la pantalla no te sigue. Jugá si te animás. Pero sabé esto: algo se está por mover.", "Jugar", "Juego", "Estás en el inodoro.", "Baño")
                }, "FIAMBREMATRIMONIO")
            }
        };

        jugador = new Jugador();
    }

    private Escena? ObtenerEscena()
    {
        int proximaSala = jugador.SalaActual + 1;
        if (Escenas.ContainsKey(proximaSala))
            return Escenas[proximaSala];
        return null; 
    }

    public Escena obtenerEscenaActual()
    {
        return Escenas[jugador.SalaActual];
    }

    public string? obtenerVideoDeEscenaActual()
    {
        var view = obtenerViewActualObjeto();
        return view?.Tipo == "Video" ? view.VideoId : null;
    }

    public int? obtenerSegundoDeCorteDeEscenaActual()
    {
        var view = obtenerViewActualObjeto();
        return view?.Tipo == "Video" ? view.SegundoDeCorte : null;
    }

    public string? obtenerTextoDeViewActual()
    {
        return obtenerViewActualObjeto()?.Texto;
    }

    public string? obtenerTituloDeViewActual()
    {
        return obtenerViewActualObjeto()?.Titulo;
    }

    public string? obtenerBotonTextoDeViewActual()
    {
        return obtenerViewActualObjeto()?.BotonTexto;
    }

    public string? obtenerProximaAccionDeViewActual()
    {
        return obtenerViewActualObjeto()?.ProximaAccion;
    }

    public View obtenerViewActualObjeto()
    {
        Escena escenaActual = obtenerEscenaActual();

        if (jugador.numViewActual >= escenaActual.Views.Count)
        {
            if (Escenas.ContainsKey(jugador.SalaActual + 1))
            {
                pasarDeSala(); // ya reinicia numViewActual a 0
                escenaActual = obtenerEscenaActual();
            }
            else
            {
                return new View("Mensaje", null, null, "¡Felicidades! Escapaste.", null, null, "Fin");
            }
        }

        return escenaActual.Views[jugador.numViewActual];
    }

    

    public string? obtenerTipoViewActual()
    {
        return obtenerViewActualObjeto()?.Tipo;
    }

    public string? obtenerProximaViewEnEscena()
    {
        var escenaActual = obtenerEscenaActual();
        int i = jugador.numViewActual + 1;
        if (i < escenaActual.Views.Count)
            return escenaActual.Views[i].Tipo;
        return null;
    }

    public void avanzarView()
    {
        jugador.avanzarView();
    }

    public View? pasarDeSala()
{
    Escena? proxima = ObtenerEscena();
    if (proxima == null)
        return null; 

    jugador.pasarDeSala(proxima.Id);
    jugador.numViewActual = 0;
    return proxima.Views[0];
}


    public int obtenerViewParaError()
    {
        return jugador.SalaActual;
    }
}
