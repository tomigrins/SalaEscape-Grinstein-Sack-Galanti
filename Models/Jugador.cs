public class Jugador
{
    public string Nombre { get;  set; }
    public int SalaActual { get;  set; }
    public List<string> ClavesObtenidas { get;  set; }
    public bool JuegoTerminado { get;  set; }
    public int numViewActual { get; set; }
    public Jugador()
    {
        Nombre = "";
        SalaActual = 0;
        numViewActual = 0;
        ClavesObtenidas = new List<string>();
        JuegoTerminado = false;
    }
    public void pasarDeSala(int idNuevo)
    {
        SalaActual = idNuevo;
        numViewActual = 0;
    }
    public void avanzarView()
    {
        numViewActual++;
    }
}