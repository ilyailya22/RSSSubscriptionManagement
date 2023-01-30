using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RSS.Api.Session;

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer";
    public const string AUDIENCE = "MyAuthClient";
    public const string KEY = "mysupersecret_secretkey!123";
    public const int LIFETIME = 300;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
