public class Escena
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<string> View { get; set; }  
    public string Video { get; set; } = "";
    public string CodigoCorrecto { get; set; } = "";
    public Escena(int id, string nombre, List<string> view, string video, string cod){
        Id = id;
        Nombre = nombre;
        View = view;
        Video = video;
        CodigoCorrecto = cod;
    }
}