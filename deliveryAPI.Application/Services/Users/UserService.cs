using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliveryAPI.Application.Interfaces.Users;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
        if (existingUser != null)
        {
            throw new Exception("Já existe um usuário com o mesmo e-mail.");
        }

        return await _userRepository.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        return await _userRepository.GetUserByIdAsync(userId);
    }

    public async Task<User> UpdateUserAsync(Guid userId, User user)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(userId);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.CEP = user.CEP;
        existingUser.Street = user.Street;
        existingUser.StreetNumber = user.StreetNumber;
        existingUser.Neighborhood = user.Neighborhood;
        existingUser.UpdatedAt = DateTime.UtcNow;

        return await _userRepository.UpdateUserAsync(userId, existingUser);
    }
}