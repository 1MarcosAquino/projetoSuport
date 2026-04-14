

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
        public void UpdateUser(string userName, string passwordHash, UserLevel level)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Level = level;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateUserName(string userName)
        {
            UserName = userName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateRole(UserLevel level)
        {
            Level = level;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
