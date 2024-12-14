using ExemploCleanArchitecture.Application.DTOs;
using ExemploCleanArchitecture.Application.Interfaces;
using ExemploCleanArchitecture.Domain.Entities;
using ExemploCleanArchitecture.Domain.Interfaces;

namespace ExemploCleanArchitecture.Application.Services;
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ICryptography _cryptography;
    public AuthenticationService(IUserRepository userRepository, ITokenGenerator tokenGenerator, ICryptography cryptography)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _cryptography = cryptography;
    }
    public async Task<ResponseUserDTO> LoginAsync(LoginRequestDTO loginRequest)
    {
        User user = await _userRepository.ReturnUserByEmailAsync(loginRequest.Email);

        if (user is null)
        {
            return null;
        }

        bool passwordIsValid = _cryptography.PasswordIsValid(loginRequest.Password, user.Password);

        if (!passwordIsValid)
        {
            return null;
        }

        var token = _tokenGenerator.GenerateToken(email: user.Email, name: user.Name);

        return new ResponseUserDTO(user.Name, user.Email, token);
    }
}

