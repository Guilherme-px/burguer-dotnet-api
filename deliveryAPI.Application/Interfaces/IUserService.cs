using System;
using System.Threading.Tasks;
using deliveryAPI.Domain.Entities;

namespace deliveryAPI.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
}
