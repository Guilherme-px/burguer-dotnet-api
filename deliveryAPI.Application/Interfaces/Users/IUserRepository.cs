using System;
using System.Threading.Tasks;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User> GetUserByEmailAsync(string email);
}
