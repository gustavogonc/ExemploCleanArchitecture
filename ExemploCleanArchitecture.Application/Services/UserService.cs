using ExemploCleanArchitecture.Application.DTOs;
using ExemploCleanArchitecture.Application.Interfaces;
using ExemploCleanArchitecture.Domain.Entities;
using ExemploCleanArchitecture.Domain.Interfaces;

namespace ExemploCleanArchitecture.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptography _cryptography;
    public UserService(IUserRepository userRepository, ICryptography cryptography)
    {
        _userRepository = userRepository;
        _cryptography = cryptography;
    }
    public async Task<List<ResponseUserDTO>> RecoverActiveUsersAsync()
    {
        List<ResponseUserDTO> listResponse = [];
        List<User> resultList = await _userRepository.ReturnActiveUsersAsync();

        foreach (var user in resultList)
        {
            ResponseUserDTO userResponse = new (Name: user.Name, Email: user.Email);

            listResponse.Add(userResponse);
        }

        return listResponse;
    }

    public async Task RegisterNewUserAsync(RegisterUserDTO userRequest)
    {
        if (string.IsNullOrWhiteSpace(userRequest.Email) || string.IsNullOrWhiteSpace(userRequest.Password))
        {
            throw new InvalidDataException("Invalid e-mail and/or password data");
        }

        string hashedPassword = _cryptography.HashPassword(userRequest.Password);

        User user = new()
        {
            Name = userRequest.Name,
            Email = userRequest.Email,
            Password = hashedPassword,
        };

        await _userRepository.CreateUserAsync(user);
    }
}

