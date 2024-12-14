using ExemploCleanArchitecture.Application.DTOs;

namespace ExemploCleanArchitecture.Application.Interfaces;
public interface IUserService
{
    Task RegisterNewUserAsync(RegisterUserDTO userRequest);
    Task<List<ResponseUserDTO>> RecoverActiveUsersAsync();
}

