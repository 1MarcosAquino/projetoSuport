using MinhaApi.Domain.Entities;
using MinhaApi.Application.DTOs.User;
using MinhaApi.Application.Interfaces;

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

        public async Task<User> SignUp(CreateUserDTO dto)
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
    }

}
