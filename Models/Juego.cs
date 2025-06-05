using Newtonsoft.Json;
public class Juego
{
    [JsonProperty]
    public int nivelActual { get; set; } = 1;
    // [JsonProperty]
    // public bool JuegoTerminado { get; set; } = false;
    [JsonProperty]
    public int codigoCorrecto { get; set;} = 0;
}