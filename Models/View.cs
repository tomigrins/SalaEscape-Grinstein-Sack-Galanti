
public class View
{
    public string Tipo { get; set; }
    public string? VideoId { get; set; }
    public int? SegundoDeCorte { get; set; }
    public string? Texto { get; set; }
    public string? Titulo {get; set;}
    public string? BotonTexto { get; set; }
    public string? ProximaAccion { get; set; }
    public string? claseMensaje {get; set;}
    public string? urlJuego {get; set;}

    public View(string tipo, string? videoId = null, int? segundoDeCorte = null,
    string? texto = null, string? botonTexto = null, string? proximaAccion = null,
    string? titulo = null, string? claseMensaje = null, 
    string? urlJuego = null)
    {
        Tipo = tipo;
        VideoId = videoId;
        SegundoDeCorte = segundoDeCorte;
        Texto = texto;
        BotonTexto = botonTexto;
        Titulo = titulo;
        this.claseMensaje = claseMensaje;
        this.urlJuego = urlJuego;
    }
}
