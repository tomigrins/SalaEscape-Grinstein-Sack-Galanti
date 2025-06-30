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
                            "Mensaje",
                            null,
                            null,
                            null,
                            null,
                            null,
                            0
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
                            "Mensaje",
                            null,
                            null,
                            null,
                            null,
                            null,
                            0
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            "Te sentás a descansar y sacás el celular. Abrís un jueguito para pasar el rato… pero algo no cierra. Los colores cambian, los sonidos se distorsionan. Las reglas del juego parecen inventarse solas. Tu reflejo en la pantalla no te sigue. Jugá si te animás. Pero sabé esto: algo se está por mover.",
                            "Jugar",
                            "Juego",
                            "Estás en el inodoro.",
                            "Inodoro"
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
                            "Inodoro"
                        ),
                        new View(
                            "Video",
                            "aJqOav3Lfcc",
                            1,
                            null,
                            null,
                            "Mensaje",
                            null,
                            null,
                            null,
                            null,
                            null,
                            0
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
                            @"El vértigo se disipa. El cielo sigue moviéndose, pero vos ya no.
                            Algo húmedo queda en tu piel. Sal, viento… ¿o sudor?
                            Escuchás olas, o quizás fue solo un susurro.
                            Elegí bien. El próximo paso puede llevarte a la calma… o a perderte para siempre.",
                            "Continuar",
                            "IngresoClave",
                            "Elige tu destino",
                            null,
                            null,
                            "Mapas",
                            new List<string>(){
                                "/imagenes/mapas/playa.jpg",
                                "/imagenes/mapas/montaña.jpg",
                                "/imagenes/mapas/ciudad.jpeg"
                            }
                        ),
                        new View(
                            "IngresoClave",
                            null,
                            null,
                            "¿No te acordás el número?",
                            "Validar número",
                            "Mensaje",
                            "Ingresá el valor:",
                            "Ingreso"
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
                    "1"
                    )
                },
                {2, new Escena(
                    2,
                    "Playa",
                    new List<View>() {
                        new View(
                            "Mensaje",
                            null,
                            null,
                            @"La montaña rusa se desvía, como si tuviera voluntad propia.
                            En lugar de frenar… vuela.
                            Cerrás los ojos, y al abrirlos, sentís la arena bajo tus pies.
                            Estás en una playa.
                            No sabés cómo llegaste, pero el sol te da en la cara y el viento huele a sal y a algo más.
                            Algo que no es del todo normal.
                            ¿Fue una imaginación? ¿Una transición mágica?
                            Quizás el océano tenga la respuesta.",
                            "Explorar la playa",
                            "Video",
                            "Un aterrizaje inesperado",
                            "playa"
                        ),
                        new View(
                            "Video",
                            "jqq_ZdD5Zwg",
                            1,
                            null,
                            null,
                            "Mensaje",
                            null,
                            null,
                            null,
                            null,
                            null,
                            10
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            @"La brisa cálida, el sonido de las olas y el murmullo del agua te envuelven.
                            No sabés bien cómo llegaste hasta acá, pero tampoco importa.
                            Hay algo liberador en no tener un plan.
                            Te sacás los zapatos, pisás la espuma y te metés al agua.
                            Sentís que todo se disuelve: el tiempo, el ruido, incluso las preguntas.
                            Solo quedás vos y el mar",
                            "Sumergirse",
                            "Video",
                            "Un chapuzón necesario",
                            "Playa"
                        ),
                        new View(
                            "Video",
                            "pqr7N8Euw0w",
                            1,
                            null,
                            null,
                            "Mensaje",
                            null,
                            null,
                            null,
                            null,
                            null,
                            0
                        ),
                        new View(
                            "Mensaje",
                            null,
                            null,
                            @"Bajo el agua todo se ve distinto…
                            Pero entre las burbujas reconocés algo: una escena conocida, animada, azul.
                            Un pez chiquito, otro olvidadizo, y una misión imposible: encontrar a alguien perdido.
                            Te dejás llevar, porque ya no nadás: flotás dentro de una película.
                            Solo hay una forma de seguir... responder bien.
                            Preparate. Esto no es un juego de memoria… ¿o sí?",
                            "Jugar bajo el agua",
                            "Juego",
                            "Algo nada distinto",
                            "Agua"
                        ),
                        new View(
                            "Juego",
                            "rTRj0SvPNUk",
                            1,
                            "La oscuridad del océano se disuelve por un instante. Una luz suave parpadea entre las algas, y los peces se acercan curiosos. Estás viendo lo mismo que ellos… pero, ¿qué es lo que están mirando realmente?",
                            "Continuar",
                            "IngresoClave",
                            null,
                            null,
                            null,
                            "BuscandoANemo",
                            new List<string>{
                                "A) Los peces ven una linterna que se le había caido a un turista",
                                "B) Los peces ven una luz que venía de un pez linterna",
                                "C) Los peces descubren una ciudad submarina iluminada",
                                "D) Los peces se acercan a una burbuja que brilla desde dentro"
                            },
                            null

                        ),
                        new View(
                            "IngresoClave",
                            null,
                            null,
                            "¿No te acordás la letra?",
                            "Validar letra",
                            "Mensaje",
                            "Ingresá la letra de la opción:",
                            "Ingreso"
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
                    "B")
                },
                {
                    3,
                    new Escena(
                        3,
                        "Paracaidas",
                        new List<View> {
                            new View(
                                "Mensaje",
                                null,
                                null,
                                @"El agua tibia se vuelve cada vez más liviana. Flotás… luego ascendés. No nadás, pero algo te eleva.
                                Sentís el viento. No sabés cuándo dejaste el mar.
                                La sal sigue en tu piel, pero ahora hay otra cosa: aire. Mucho aire.
                                Tus pies ya no tocan nada. Mirás abajo… y el mundo es una miniatura.",
                                "Seguir flotando",
                                "Video",
                                "Algo te eleva",
                                "Playa",
                                null,
                                null,
                                null,
                                null
                            ),
                            new View(
                                "Video",
                                "eAS2tg-zN_4",
                                1,
                                null,
                                null,
                                "Mensaje",
                                null,
                                null,
                                null,
                                null,
                                null,
                                3
                            ),
                            new View(
                                "Mensaje",
                                null,
                                null,
                                @"El suelo no se acerca.
                                Las nubes giran lento, como si el tiempo también flotara.
                                Estás colgando de un paracaídas, sí… pero esto no es solo una caída.
                                Hay algo raro en el aire. Un destello frente a tus ojos.
                                Un juego.
                                ¿Lo imaginás? ¿O lo ves de verdad?
                                Quizás la única forma de avanzar… sea jugar.",
                                "Jugar",
                                "Juego",
                                "El paracaídas se pausa",
                                "Paracaídas",
                                null,
                                null,
                                null,
                                null
                            ),
                            new View(
                                "Juego",
                                null,
                                null,
                                @"instrucciones!"
                            ),
                            new View(
                            "IngresoClave",
                            null,
                            null,
                            "¿No te acordás la letra?",
                            "Validar letra",
                            "Mensaje",
                            "Ingresá la letra de la opción:",
                            "Ingreso"
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
                        "1234"
                    )
                }, 
                {
                    4, new Escena(
                        4,
                        "Portal",
                        new List<View>{
                            new View(
                                "Mensaje",
                                null,
                                null
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
                pasarDeSala(); 
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
}
