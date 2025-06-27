using Newtonsoft.Json;
public class Juego
{
    public Dictionary<int, Escena> Escenas { get; set; }
    public Jugador jugador { get; set; }

    public void inicializarJuego()
    {
        Escenas = new Dictionary<int, Escena> {
            {
                0,
                new Escena(
                    0,
                    "Casamiento",
                    new List<View> {
                        new View(
                            "Video",
                            "ardtvdR28SQ",
                            1,
                            null,
                            null,
                            "Mensaje"
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            "Estás en un casamiento. La música suena lejana, la pista de baile vibra, pero algo te incomoda. Esa sensación ineludible... te dan ganas de ir al baño. Sentís una presencia extraña en el ambiente, como si no fueras la única en apurarte a salir de ahí. Presioná el botón si te animás a continuar.",
                            "Ir al baño",
                            "Video",
                            "Te dan ganas de ir al baño",
                            "Baño"
                        ),
                        new View(
                            "Video",
                            "wpHC614ZHMY",
                            1,
                            null,
                            null,
                            "Mensaje"
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            "Te sentás a descansar y sacás el celular. Abrís un jueguito para pasar el rato… pero algo no cierra. Los colores cambian, los sonidos se distorsionan. Las reglas del juego parecen inventarse solas. Tu reflejo en la pantalla no te sigue. Jugá si te animás. Pero sabé esto: algo se está por mover.",
                            "Jugar",
                            "Juego",
                            "Estás en el inodoro.",
                            "Baño"
                        ),
                        new View(
                            "Juego",
                            null,
                            null,
                            null,
                            "Siguiente",
                            "IngresoClave",
                            null,
                            null,
                            "https://view.genially.com/685ab2b73ef4f5a83fdda5bb",
                            "Genially"
                        ),
                        new View(
                            "IngresoClave",
                            null,
                            null,
                            "¿No te acordás el código?",
                            "Validar código",
                            "Mensaje",
                            "Ingresá el código:",
                            "Ingreso",
                            null
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            "¡Enhorabuena! Presiona el botón para conocer tu próximo destino",
                            "Continuar",
                            "Mensaje",
                            "¡Pasaste!",
                            "Pasaste",
                            null
                        )
                        
                    },
                    "INODOROEMBRUJADO"
                )
            },
            {
                1,
                new Escena(
                    1,
                    "MONTAÑA RUSA",
                    new List<View>{
                        new View(
                            "Mensaje",
                            null,
                            null,
                            @"Algo chorreó del borde del inodoro cuando lo cerraste. Una carcajada hueca resonó, como si las cañerías rieran de vos.  
                            Un destello rojo iluminó el piso... y todo se volvió oscuro.
                            Cuando abrís los ojos, ya no estás en el baño.  
                            El viento te golpea la cara. Estás atada a un asiento que vibra, cruje.  
                            Las vías bajo tus pies se deshacen y una voz metálica murmura:
                            “Ya no hay marcha atrás”",
                            "Continuar",
                            "Video",
                            "El inodoro estaba embrujado",
                            "Baño"
                        ),
                        new View(
                            "Video",
                            "aJqOav3Lfcc",
                            1,
                            null,
                            null,
                            "Mensaje"
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            @"La montaña rusa trepa. El aire se vuelve más fino, más frío.
                            Abajo, todo es miniatura. Excepto el miedo.
                            Frente a vos, aparecen tres mapas. No sabés cómo llegaron a tus manos.
                            Solo uno traza un camino hacia una playa segura.
                            Los otros… bueno, no hay tiempo.
                            Tenés que elegir antes de caer.",
                            "Continuar",
                            "Juego",
                            "La gran elección",
                            "MontañaRusa"
                        ),
                        new View(
                            "Juego",
                            null,
                            null,
                            "Respirá hondo y tomate un tiempo para decidir tu destino. Respirá hondo... Una decisión incorrecta podría costarte la vida.",
                            "Continuar",
                            "IngresoClave",
                            "Elige tu destino",
                            null,
                            null,
                            "Mapas",
                            new List<string>(){
                                "/imagenes/mapas/playa.jpg",
                                "/imagenes/mapas/montaña.jpg",
                                "/imagenes/mapas/ciudad.avif"
                            }
                        )
                    },
                    "1234"
                )
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
        View view = obtenerViewActualObjeto();
        return view?.Tipo == "Video" ? view.VideoId : null;
    }

    public int? obtenerSegundoDeCorteDeEscenaActual()
    {
        View view = obtenerViewActualObjeto();
        return view?.Tipo == "Video" ? view.SegundoDeCorte : null;
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
