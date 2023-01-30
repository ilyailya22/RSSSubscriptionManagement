using Newtonsoft.Json;

namespace RSS.Entities.Models.Auth;

public class AuthResult
{
    [JsonProperty("token")]
    public string Token { get; set; }
}
