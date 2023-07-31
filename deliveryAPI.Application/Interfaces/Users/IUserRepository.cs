using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> UpdateUserAsync(Guid userId, User user);
}
