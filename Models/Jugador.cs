public class Jugador
{
    public string Nombre { get; private set; }
    public int SalaActual { get; private set; }
    public List<string> ClavesObtenidas { get; private set; }
    public bool JuegoTerminado { get; private set; }
    public int numViewActual { get; private set; }
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