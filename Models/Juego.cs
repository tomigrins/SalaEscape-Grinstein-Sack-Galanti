using Newtonsoft.Json;
public static class Juego
{
    public Dictionary<int, Escena> Escenas {private set; get;}
    public Jugador jugador {private set;get;}
    private Escena ObtenerEscena()
    {
        return ;
    }
    public  string obtenerProximaSala(){
        Escena escenaProxima = ObtenerEscena();
        return escenaProxima.View;
    }
    public  string obtenerViewParaError (){

    }
    public void inicializarJuego(){
        Escenas= new Dictionary<int, Escena>{
            {0, new Escena { Id = 0, Nombre = "Casamiento", View = "Casamiento", CodigoCorrecto = "FIAMBREMATRIMONIO" }},
            {1, new Escena { Id = 1, Nombre = "Casa del Terror", View = "CasaDelTerror", CodigoCorrecto = "MALDITOESPEJO" }},
            {2, new Escena { Id = 2, Nombre = "Desierto", View = "Desierto", CodigoCorrecto = "CAMELORD"}},
            {3, new Escena { Id = 3, Nombre = "Playa", View = "Playa", CodigoCorrecto = "AGUAESCAPE" }},
            {4, new Escena { Id = 4, Nombre = "Paracaídas", View = "Paracaidas", CodigoCorrecto = "SKYDROP"}},
            {5, new Escena { Id = 5, Nombre = "Portal", View = "Portal", CodigoCorrecto = "PORTALCAMA"}}
        };
    }
}