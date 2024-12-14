namespace ExemploCleanArchitecture.Domain.Interfaces;
public interface ICryptography
{
    string HashPassword(string password);
    bool PasswordIsValid(string passwordInput, string userPassword);
}

