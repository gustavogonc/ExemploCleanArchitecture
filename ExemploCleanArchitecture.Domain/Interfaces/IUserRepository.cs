using ExemploCleanArchitecture.Domain.Entities;

namespace ExemploCleanArchitecture.Domain.Interfaces;
public interface IUserRepository
{
    Task CreateUserAsync(User userRequest);
    Task<User> ReturnUserByEmailAsync(string email);
    Task<List<User>> ReturnActiveUsersAsync();
}

