

using MinhaApi.Domain.Enums;

namespace MinhaApi.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string UserName { get; private set; } = string.Empty;

        public string PasswordHash { get; private set; } = string.Empty;

        public UserLevel Level { get; private set; } = UserLevel.Employee;

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        private readonly List<Ticket> _tickets = new();
        public IReadOnlyCollection<Ticket> Tickets => _tickets;

        // Construtor
        public User(string userName, string passwordHash, UserLevel level)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Level = level;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Método de domínio (exemplo)
        public void UpdateUser(string userName, UserLevel level)
        {
            UserName = userName;
            Level = level;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

// using System.ComponentModel.DataAnnotations;
// using MinhaApi.Domain.enums;

// namespace MinhaApi.Domain.Entities
// {
//     public class User
//     {
//         [Key]
//         public int Id { get; set; }

//         [Required]
//         public string UserName { get; set; } = string.Empty;

//         [Required]
//         public string PasswordHash { get; set; } = string.Empty;

//         [Required]
//         public UserLevel Level { get; set; } = UserLevel.Employee;

//         public DateTime CreatedAt { get; set; }

//         public DateTime UpdatedAt { get; set; }

//         public List<Ticket> Tickets { get; set; } = new();
//     }
// }