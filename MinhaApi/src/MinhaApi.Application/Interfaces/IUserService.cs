
using MinhaApi.Application.DTOs.User;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> SignUp(SignUpDTO dto);

        Task<string?> SignIn(string username, string password);

        Task<UserResponseDTO?> GetById(int id);

        Task<List<UserResponseDTO>> GetAll();

        Task<bool> Update(int id, UserUpdateDTO updatedUser);

        Task<bool> Remove(int id);
    }
}