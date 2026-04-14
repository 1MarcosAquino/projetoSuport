using MinhaApi.Domain.Entities;
using MinhaApi.Application.DTOs.User;
using MinhaApi.Application.Interfaces;
using BCrypt.Net;

namespace MinhaApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<User> SignUp(SignUpDTO dto)
        {
            var user = new User(dto.UserName, _passwordHasher.Hash(dto.Password), dto.Role);
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<string?> SignIn(string username, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(username);
            if (user == null) return null;

            if (!_passwordHasher.Verify(password, user.PasswordHash)) return null;

            return _tokenService.GenerateToken(user);
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetAll()
        {
            var all = await _userRepository.GetAllAsync();

            return all.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Level = user.Level
            }).ToList();
        }

        public async Task<bool> Update(int id, UserUpdateDTO updatedUser)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return false;

            if (!string.IsNullOrEmpty(updatedUser.UserName))
            {
                var UserNameExists = await _userRepository.GetByUserNameAsync(updatedUser.UserName);

                if (UserNameExists != null && UserNameExists.Id != id) return false;

                user.UpdateUserName(updatedUser.UserName);
            }

            if (updatedUser.Level.HasValue)
                user.UpdateRole(updatedUser.Level.Value);

            if (!string.IsNullOrEmpty(updatedUser.Password))
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(updatedUser.Password);

                user.UpdatePassword(passwordHash);
            }

            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return false;

            await _userRepository.RemoveAsync(user);

            return true;
        }
    }

}
