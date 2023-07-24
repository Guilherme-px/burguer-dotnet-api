using System;
using System.Threading.Tasks;
using burguerAPI.Domain.Entities;

namespace burguerAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
