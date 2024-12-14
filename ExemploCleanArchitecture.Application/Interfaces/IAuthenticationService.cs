using ExemploCleanArchitecture.Application.DTOs;

namespace ExemploCleanArchitecture.Application.Interfaces;
public interface IAuthenticationService
{
    Task<ResponseUserDTO> LoginAsync(LoginRequestDTO loginRequest);
}

