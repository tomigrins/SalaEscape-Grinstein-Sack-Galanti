using Newtonsoft.Json;
public class Juego
{
    public Dictionary<int, Escena> Escenas { private set; get; }
    public Jugador jugador { private set; get; }
    private Escena ObtenerEscena()
    {
        return Escenas[jugador.SalaActual + 1];
    }
    public string pasarDeSala()
    {
        Escena escenaProxima = ObtenerEscena();
        jugador.pasarDeSala(escenaProxima.Id);
        return escenaProxima.View[jugador.numViewActual];
    }
    public string obtenerProximaViewEnEscena()
    {
        Escena escenaActual = obtenerEscenaActual();
        int i = jugador.numViewActual + 1;
        if (i < escenaActual.View.Count)
        {
            return escenaActual.View[i];
        }
        return null;
    }
    public void avanzarView()
    {
        jugador.avanzarView();
    }


    public int obtenerViewParaError()
    {
        return jugador.SalaActual;
    }
    public Escena obtenerEscenaActual()
    {
        Escena escenaActual = Escenas[jugador.SalaActual];
        return escenaActual;
    }
    public void inicializarJuego()
    {
        Escenas = new Dictionary<int, Escena>{
            {0, new Escena (0, "Casamiento", new List<string> (){"Video", "Casamiento", "Mensaje" ,"Baño"}, "ardtvdR28SQ", "FIAMBREMATRIMONIO" )},
            // {1, new Escena (1, "Montaña rusa", "MontañaRusa","MALDITOESPEJO" )},
            // {2, new Escena (2,"Desierto", "Desierto","CAMELORD")},
            // {3, new Escena (3, "Playa", "Playa","AGUAESCAPE" )},
            // {4, new Escena (4, "Paracaídas", "Paracaidas", "SKYDROP")},
            // {5, new Escena (5, "Portal", "Portal", "PORTALCAMA")}
        };
        jugador = new Jugador();
    }
    public string obtenerViewActual()
    {
        Escena escenaActual = obtenerEscenaActual();
        return escenaActual.View[jugador.numViewActual];
    }
}