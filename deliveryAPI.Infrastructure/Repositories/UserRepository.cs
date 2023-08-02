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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> UpdateUserAsync(Guid userId, User user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.CEP = user.CEP;
            existingUser.Street = user.Street;
            existingUser.StreetNumber = user.StreetNumber;
            existingUser.Neighborhood = user.Neighborhood;
            existingUser.IsAdmin = user.IsAdmin;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (existingUser != null)
            {
                _dbContext.Users.Remove(existingUser);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
