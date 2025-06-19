using Newtonsoft.Json;
// public class Juego
// {
//     public Dictionary<int, Escena> Escenas { set; get; }
//     public Jugador jugador { set; get; }
//     private Escena ObtenerEscena()
//     {
//         return Escenas[jugador.SalaActual + 1];
//     }
//     public string pasarDeSala()
//     {
//         Escena escenaProxima = ObtenerEscena();
//         jugador.pasarDeSala(escenaProxima.Id);
//         return escenaProxima.View[jugador.numViewActual];
//     }
//     public string obtenerProximaViewEnEscena()
//     {
//         Escena escenaActual = obtenerEscenaActual();
//         int i = jugador.numViewActual + 1;
//         if (i < escenaActual.View.Count)
//         {
//             return escenaActual.View[i];
//         }
//         return null;
//     }
//     public void avanzarView()
//     {
//         jugador.avanzarView();
//     }


//     public int obtenerViewParaError()
//     {
//         return jugador.SalaActual;
//     }
//     public Escena obtenerEscenaActual()
//     {
//         Escena escenaActual = Escenas[jugador.SalaActual];
//         return escenaActual;
//     }
//     public string obtenerVideoDeEscenaActual()
//     {
//         Escena escena = obtenerEscenaActual();
//         if (escena.View[jugador.numViewActual] == "Video")
//         {
//             return escena.Videos.;
//         }
//         return null;
//     }


//     public void inicializarJuego()
//     {
//         new Escena(0, "Casamiento", new List<View> {
//             new View("Video", "ardtvdR28SQ", 5),
//             new View("Mensaje", texto: "Estás en un casamiento. La música suena lejana, la pista de baile vibra, pero algo te incomoda. Esa sensación ineludible... te dan ganas de ir al baño. Sentís una presencia extraña en el ambiente, como si no fueras la única en apurarte a salir de ahí. Presioná el botón si te animás a continuar.", botonTexto: "Ir al baño", proximaAccion: "Baño", Titulo: "Te dan ganas de ir al baño"),
//             new View("Video", "wpHC614ZHMY", 19)
//         }, "FIAMBREMATRIMONIO");
//         jugador = new Jugador();
//     }
//     public string obtenerViewActual()
//     {
//         Escena escenaActual = obtenerEscenaActual();
//         return escenaActual.View[jugador.numViewActual];
//     }
// }

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
                    new View("Mensaje", null,null, "Estás en un casamiento. La música suena lejana, la pista de baile vibra, pero algo te incomoda. Esa sensación ineludible... te dan ganas de ir al baño. Sentís una presencia extraña en el ambiente, como si no fueras la única en apurarte a salir de ahí. Presioná el botón si te animás a continuar.", "Ir al baño", "Video", "Te dan ganas de ir al baño"),
                    new View("Video", "wpHC614ZHMY", 20, null, null, "Mensaje"),
                    new View("Mensaje", null, null, "Te sentás a descansar y sacás el celular. Abrís un jueguito para pasar el rato… pero algo no cierra. Los colores cambian, los sonidos se distorsionan. Las reglas del juego parecen inventarse solas. Tu reflejo en la pantalla no te sigue. Jugá si te animás. Pero sabé esto: algo se está por mover.", "Jugar", "Juego", "Estás en el inodoro.")
                }, "FIAMBREMATRIMONIO")
            }
        };

        jugador = new Jugador();
    }

    private Escena ObtenerEscena()
    {
        return Escenas[jugador.SalaActual + 1];
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

    public string pasarDeSala()
    {
        Escena proxima = ObtenerEscena();
        jugador.pasarDeSala(proxima.Id);
        return proxima.Views[jugador.numViewActual].Tipo;
    }

    public int obtenerViewParaError()
    {
        return jugador.SalaActual;
    }
}
