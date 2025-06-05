namespace SalaEscape_Grinstein_Sack_Galanti.Models;
using Newtonsoft.Json;
public class ErrorViewModel
{
    [JsonProperty]
    public string? RequestId { get; set; }
    [JsonProperty]
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
