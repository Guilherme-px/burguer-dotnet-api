using System;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using deliveryAPI.Application.Interfaces.Users;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<User> _userValidator;

    public UserService(IUserRepository userRepository, IValidator<User> userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }

    public async Task<User> CreateUserAsync(User user, string confirmPassword)
    {
        var validationResult = await _userValidator.ValidateAsync(user);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
        if (existingUser != null)
        {
            throw new Exception("Já existe um usuário com o mesmo e-mail!");
        }

        if (confirmPassword == null)
        {
            throw new Exception("A senha e a confirmação é obrigatória!");
        }

        if (user.Password != confirmPassword)
        {
            throw new Exception("A senha e a confirmação de senha não correspondem!");
        }

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = hashedPassword;

        return await _userRepository.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<IActionResult> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return new NotFoundObjectResult("Usuário não encontrado!");
        }

        return new OkObjectResult(user);
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
        existingUser.IsAdmin = user.IsAdmin;
        existingUser.UpdatedAt = DateTime.UtcNow;

        if (!string.IsNullOrWhiteSpace(user.Password))
        {
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        }

        return await _userRepository.UpdateUserAsync(userId, existingUser);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await _userRepository.DeleteUserAsync(userId);
    }
}