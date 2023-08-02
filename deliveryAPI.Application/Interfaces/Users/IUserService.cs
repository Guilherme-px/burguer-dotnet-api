using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserService
{
    Task<User> CreateUserAsync(User user, string confirmPassword);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<IActionResult> GetUserByIdAsync(Guid userId);
    Task<User> UpdateUserAsync(Guid userId, User user);
    Task DeleteUserAsync(Guid userId);
}
