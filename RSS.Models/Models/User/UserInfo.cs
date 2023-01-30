using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RSS.Entities.Models.Enums;

namespace RSS.Entities.Models.User;

public record UserInfo
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("birthday")]
    public DateTime Birthday { get; set; }

    [JsonProperty("gender")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Gender Gender { get; set; }
}
