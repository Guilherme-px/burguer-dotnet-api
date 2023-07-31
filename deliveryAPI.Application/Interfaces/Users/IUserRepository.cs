using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid userId);
}
