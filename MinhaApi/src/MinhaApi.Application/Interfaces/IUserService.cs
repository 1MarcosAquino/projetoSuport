
using MinhaApi.Application.DTOs.User;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> SignUp(CreateUserDTO dto);

        Task<string?> SignIn(string username, string password);
    }
}