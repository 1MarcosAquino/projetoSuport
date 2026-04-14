using MinhaApi.Domain.Enums;

namespace MinhaApi.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public TicketStatus Status { get; private set; } = TicketStatus.Aberto;

        public TicketPriority Priority { get; private set; } = TicketPriority.Baixa;

        public SupportLevel SupportLevel { get; private set; } = SupportLevel.N1;

        public int UserId { get; private set; }
        public User? User { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedByUser { get; private set; } = null!;

        public int? AssignedToUserId { get; private set; }
        public User? AssignedToUser { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Construtor
        public Ticket(
            string title,
            string description,
            TicketPriority priority,
            SupportLevel supportLevel,
            int userId,
            int createdByUserId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            SupportLevel = supportLevel;
            UserId = userId;
            CreatedByUserId = createdByUserId;

            Status = TicketStatus.Aberto;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Métodos de domínio
        public void Update(string title, string description, TicketPriority priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignTo(int userId)
        {
            AssignedToUserId = userId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangeStatus(TicketStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}