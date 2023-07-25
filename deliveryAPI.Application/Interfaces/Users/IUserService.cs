using System;
using System.Threading.Tasks;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Application.Interfaces.Users;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
}
