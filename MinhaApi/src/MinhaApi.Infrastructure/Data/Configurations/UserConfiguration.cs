using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.Level)
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.UpdatedAt)
                   .IsRequired();

            builder.HasMany(u => u.Tickets)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

