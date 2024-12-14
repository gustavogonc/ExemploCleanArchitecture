namespace ExemploCleanArchitecture.Domain.Interfaces;
public interface ITokenGenerator
{
    string GenerateToken(string email, string name);
}

