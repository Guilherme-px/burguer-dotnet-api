using System;
using System.Threading.Tasks;
using deliveryAPI.Domain.Entities;

namespace deliveryAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
