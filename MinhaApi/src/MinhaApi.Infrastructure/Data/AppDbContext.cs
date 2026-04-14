using Microsoft.EntityFrameworkCore;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

// using Microsoft.EntityFrameworkCore;
// using MinhaApi.Domain.Entities;

// namespace MinhaApi.Infrastructure.Data
// {
//     public class AppDbContext : DbContext
//     {
//         public DbSet<User> Users { get; set; }

//         public DbSet<Ticket> Tickets { get; set; }

//         public AppDbContext(DbContextOptions options) : base(options) { }

//         public override int SaveChanges()
//         {
//             var now = DateTime.UtcNow;

//             foreach (var entry in ChangeTracker.Entries())
//             {
//                 if (entry.Entity is User user)
//                 {
//                     ModifyDate(entry, user, now);
//                 }

//                 if (entry.Entity is Ticket ticket)
//                 {
//                     ModifyDate(entry, ticket, now);
//                 }
//             }

//             return base.SaveChanges();
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             // Criador do ticket
//             modelBuilder.Entity<Ticket>()
//                 .HasOne(t => t.CreatedByUser)
//                 .WithMany()
//                 .HasForeignKey(t => t.CreatedByUserId)
//                 .OnDelete(DeleteBehavior.Restrict);

//             // Responsável pelo atendimento
//             modelBuilder.Entity<Ticket>()
//                 .HasOne(t => t.AssignedToUser)
//                 .WithMany()
//                 .HasForeignKey(t => t.AssignedToUserId)
//                 .OnDelete(DeleteBehavior.Restrict);
//         }

//         private void ModifyDate(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, ModelBase entity, DateTime now)
//         {
//             if (entry.State == EntityState.Added)
//             {
//                 entity.CreatedAt = now;
//                 entity.CreatedAt = now;
//             }
//             else if (entry.State == EntityState.Modified)
//             {
//                 entity.UpdatedAt = now;
//             }
//         }
//     }
// }