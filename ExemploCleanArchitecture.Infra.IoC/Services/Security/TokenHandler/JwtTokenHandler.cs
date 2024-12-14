using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExemploCleanArchitecture.Infra.IoC.Services.Security.TokenHandler;
public abstract class JwtTokenHandler
{
    public static SymmetricSecurityKey SecurityKey(string signinKey)
    {
        var bytes = Encoding.UTF8.GetBytes(signinKey);

        return new SymmetricSecurityKey(bytes);
    }
}

