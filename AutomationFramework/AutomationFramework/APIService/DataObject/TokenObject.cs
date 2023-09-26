using Newtonsoft.Json;

public class TokenObject
{
    [JsonProperty("token")]
    public string? Token { get; set; }

    [JsonProperty("expires")]
    public DateTime? Expires { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("result")]
    public string? Result { get; set; }

}