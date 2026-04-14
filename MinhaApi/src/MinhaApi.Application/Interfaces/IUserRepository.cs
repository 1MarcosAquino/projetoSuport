using MinhaApi.Domain.Entities;

namespace MinhaApi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByUserNameAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
}