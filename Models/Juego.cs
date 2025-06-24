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
                            null,
                            "Ingreso",
                            null,
                            null,
                            "Memotest",
                            new Dictionary<string, object> {
                                { "Cartas", new List<string> {
                                    "/imagenes/memotest/bruja.png",
                                    "/imagenes/memotest/inodoro.png",
                                    "/imagenes/memotest/casados.png",
                                    "/imagenes/memotest/celular.png",
                                    "/imagenes/memotest/puerta.png",
                                    "/imagenes/memotest/inodoro.png",
                                    "/imagenes/memotest/puerta.png",
                                    "/imagenes/memotest/alianzas.png",
                                    "/imagenes/memotest/casados.png",
                                    "/imagenes/memotest/montaña_rusa.png",
                                    "/imagenes/memotest/cama.png",
                                    "/imagenes/memotest/celular.png",
                                    "/imagenes/memotest/bruja.png",
                                    "/imagenes/memotest/alianzas.png",
                                    "/imagenes/memotest/cama.png",
                                    "/imagenes/memotest/montaña_rusa.png"
                                }},
                                { "Pares especiales", new List<int>{ 0, 1, 9 }},
                                { "Letras reveladas", new List<char>() },
                                { "CodigoIngresado", "" },
                                { "JuegoFinalizado", false },
                                { "Gano", false },
                                { "PartesValidadas", new Dictionary<int, bool> {
                                    {0, false}, {1, false}, {9, false}
                                }},
                                { "PartesCodigo", new Dictionary<int, string> {
                                    {0, "ROEMBRU"},
                                    {1, "INODO"},
                                    {9, "JADO"}
                                }},
                                { "MensajesEspeciales", new Dictionary<int, (string titulo, string mensaje)> {
                                    {
                                        1,
                                        ("Carta del inodoro",
                                        @"Te sentás, el eco <span style=""color:red;"">I</span>nmóvil del silencio<br>
                                        te envuelve en el <span style=""color:red;"">N</span>eblina de lo impensado.<br>
                                        El agua cae, un <span style=""color:red;"">O</span>scuro gorgoteo te responde.<br>
                                        Algo se mueve <span style=""color:red;"">D</span>entro, no es solo tu reflejo.<br>
                                        Un susurro grita: “<span style=""color:red;"">O</span>lvidá salir... si podés.”")
                                    },
                                    {
                                        0,
                                        ("Carta de la bruja",
                                        @"El espejo se quiebra con un <span style=""color:red;"">R</span>uido seco.<br>
                                        No hay nadie, pero un <span style=""color:red;"">O</span>jo se abre en la sombra.<br>
                                        Te observa. Te estudia. Susurra con voz <span style=""color:red;"">E</span>terna:<br>
                                        “<span style=""color:red;"">M</span>irá lo que no querés ver”.<br>
                                        Una <span style=""color:red;"">B</span>risa te envuelve.<br>
                                        No es viento. Es <span style=""color:red;"">R</span>ezo. Es <span style=""color:red;"">U</span>n conjuro.")
                                    },
                                    {
                                        9,
                                        ("Carta de la montaña rusa",
                                        @"Subís. Pero no hay rieles. No hay fin.<br>
                                        Solo un <span style=""color:red;"">J</span>adeo que crece con el viento.<br>
                                        Tu cuerpo no pesa, tu mente no calla.<br>
                                        Gritás. Y nadie responde, salvo el <span style=""color:red;"">A</span>ullido.<br>
                                        Un <span style=""color:red;"">D</span>estello te ciega.<br>
                                        Al abrir los ojos, hay <span style=""color:red;"">O</span>tros ojos. No son tuyos.")
                                    }
                                }}
                            }
                        )
                    },
                    "INODOROEMBRUJADO"
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
