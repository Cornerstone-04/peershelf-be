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

            // BorrowTransaction relationship with User (Borrower)
            modelBuilder.Entity<BorrowTransaction>()
                .HasOne(bt => bt.Borrower)
                .WithMany()
                .HasForeignKey(bt => bt.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict); // <--- Restrict or NoAction

            // BorrowTransaction relationship with Resource
            modelBuilder.Entity<BorrowTransaction>()
                .HasOne(bt => bt.Resource)
                .WithMany()
                .HasForeignKey(bt => bt.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Resource relationship with User (Uploader)
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.UploadedBy)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.UploadedById)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
