using System.ComponentModel.DataAnnotations;
using MinhaApi.Domain.Enums;

namespace MinhaApi.Application.DTOs.User
{
    public class UserUpdateDTO
    {
        [MaxLength(50)]
        public string? UserName { get; set; }

        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [MaxLength(100)]
        public string? Password { get; set; }

        public UserLevel? Role { get; set; }
    }
}