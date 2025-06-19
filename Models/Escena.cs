public class Escena
{
    public int Id { get; set; }
    public string Nombre { get; set; } 
    public List<View> Views { get; set; }  
    public string CodigoCorrecto { get; set; } 
    public Escena(int id, string nombre, List<View> views, string cod){
        Id = id;
        Nombre = nombre;
        Views = views;
        Videos = videos;
        CodigoCorrecto = cod;

    }
}