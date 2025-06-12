using Newtonsoft.Json;
public class Juego
{
    public Dictionary<int, Escena> Escenas {private set; get;}
    public Jugador jugador {private set;get;}
    private Escena ObtenerEscena()
    {
        return Escenas[jugador.SalaActual + 1];
    }
    public string obtenerProximaSala(){
        Escena escenaProxima = ObtenerEscena();
        return escenaProxima.View;
    }
    public string obtenerProximaViewEnEscena(){
    Escena escenaActual = obtenerEscenaActual();
    int indexActual = escenaActual.View.IndexOf(jugador.ViewActual);
    if (indexActual >= 0 && indexActual < escenaActual.View.Count - 1){
        return escenaActual.View[indexActual + 1];
    }
    return null; // o alguna vista final, o "Error"
}

    public int obtenerViewParaError (){
        return jugador.SalaActual;
    }
    public Escena obtenerEscenaActual(){
        Escena escenaActual = Escenas[jugador.SalaActual];
        return escenaActual;
    }
    public void inicializarJuego(){
        Escenas= new Dictionary<int, Escena>{
            {0, new Escena (0, "Casamiento", new List<string> (){"Video", "Casamiento", "Mensaje" ,"Baño"}, "ardtvdR28SQ", "FIAMBREMATRIMONIO" )},
            {1, new Escena (1, "Montaña rusa", "MontañaRusa","MALDITOESPEJO" )},
            {2, new Escena (2,"Desierto", "Desierto","CAMELORD")},
            {3, new Escena (3, "Playa", "Playa","AGUAESCAPE" )},
            {4, new Escena (4, "Paracaídas", "Paracaidas", "SKYDROP")},
            {5, new Escena (5, "Portal", "Portal", "PORTALCAMA")}
        };
        jugador = new Jugador();
    }
}