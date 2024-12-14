using ExemploCleanArchitecture.Domain.Interfaces;

namespace ExemploCleanArchitecture.Infra.IoC.Services.Crypt
{
    public class Cryptography : ICryptography
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool PasswordIsValid(string passwordInput, string userPassword)
        {
            return BCrypt.Net.BCrypt.Verify(passwordInput, userPassword);
        }
    }
}
