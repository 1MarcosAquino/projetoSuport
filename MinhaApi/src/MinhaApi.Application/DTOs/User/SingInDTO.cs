using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Application.DTOs.User
{
    public class SingInDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}