﻿using Newtonsoft.Json;

namespace RSS.Entities.Models.User;

public class UserLoginModel
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
}
