
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}