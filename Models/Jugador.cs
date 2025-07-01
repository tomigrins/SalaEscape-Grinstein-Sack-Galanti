public class Jugador
{
    public int SalaActual { get;  set; }
    public int numViewActual { get; set; }
    public Jugador()
    {
        SalaActual = 0;
        numViewActual = 0;
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