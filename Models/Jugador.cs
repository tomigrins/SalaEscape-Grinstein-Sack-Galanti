public class Jugador
{
    public string Nombre { get; private set; } = "";
    public int SalaActual { get; private set; } = 0;
    public List<string> ClavesObtenidas { get; private set; } = new List<string>();
    public bool JuegoTerminado { get; private set; } = false;
}