using AcademicResourceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademicResourceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique email for users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // User Id as PK
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // User - Resource (Uploader)
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.UploadedBy)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.UploadedById)
                .OnDelete(DeleteBehavior.Cascade);

            // User - BorrowTransaction (Borrower)
            modelBuilder.Entity<BorrowTransaction>()
                .HasOne(bt => bt.Borrower)
                .WithMany(u => u.BorrowedResources)
                .HasForeignKey(bt => bt.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Resource - BorrowTransaction
            modelBuilder.Entity<BorrowTransaction>()
                .HasOne(bt => bt.Resource)
                .WithMany()
                .HasForeignKey(bt => bt.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Notification - User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
