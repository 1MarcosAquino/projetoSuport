using System.ComponentModel.DataAnnotations;
using MinhaApi.Domain.Enums;

namespace MinhaApi.Application.DTOs.User
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;

        public UserLevel Role { get; set; } = UserLevel.Employee;
    }
}