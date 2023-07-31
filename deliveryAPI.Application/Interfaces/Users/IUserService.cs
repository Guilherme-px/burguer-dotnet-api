using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid userId);
}
