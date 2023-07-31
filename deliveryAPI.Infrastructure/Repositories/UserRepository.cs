using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using deliveryAPI.Domain.Entities.Users;
using deliveryAPI.Application.Interfaces.Users;
using deliveryAPI.Infrastructure.Context;

namespace deliveryAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DeliveryDbContext _dbContext;

        public UserRepository(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
