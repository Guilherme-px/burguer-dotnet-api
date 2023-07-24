using System;
using System.Threading.Tasks;
using burguerAPI.Domain.Entities;

namespace burguerAPI.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
}
