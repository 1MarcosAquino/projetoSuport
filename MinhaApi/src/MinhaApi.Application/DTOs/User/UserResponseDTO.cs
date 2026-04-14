using MinhaApi.Domain.Enums;

namespace MinhaApi.Application.DTOs.User
{
    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public UserLevel Role { get; set; }
    }
}