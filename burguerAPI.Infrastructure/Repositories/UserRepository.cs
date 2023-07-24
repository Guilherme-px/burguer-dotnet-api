using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using burguerAPI.Domain.Entities;
using burguerAPI.Application.Interfaces;
using burguerAPI.Infrastructure.Context;

namespace burguerAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BurguerDbContext _dbContext;

        public UserRepository(BurguerDbContext dbContext)
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
    }
}
