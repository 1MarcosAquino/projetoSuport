using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infrastructure.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(t => t.Status)
                   .IsRequired();

            builder.Property(t => t.Priority)
                   .IsRequired();

            builder.Property(t => t.SupportLevel)
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            builder.Property(t => t.UpdatedAt)
                   .IsRequired();

            // Relacionamento principal (Ticket → User)
            builder.HasOne(t => t.User)
                   .WithMany(u => u.Tickets)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Criado por
            builder.HasOne(t => t.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(t => t.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Atribuído para
            builder.HasOne(t => t.AssignedToUser)
                   .WithMany()
                   .HasForeignKey(t => t.AssignedToUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}