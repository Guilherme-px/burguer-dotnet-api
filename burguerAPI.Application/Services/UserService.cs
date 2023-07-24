using System;
using System.Threading.Tasks;
using burguerAPI.Application.Interfaces;
using burguerAPI.Domain.Entities;

namespace burguerAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new Exception("Já existe um usuário com o mesmo e-mail.");
            }

            return await _userRepository.AddAsync(user);
        }
    }
}
