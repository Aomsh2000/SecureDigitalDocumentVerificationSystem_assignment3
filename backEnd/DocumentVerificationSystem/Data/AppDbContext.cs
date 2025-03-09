using Microsoft.EntityFrameworkCore;
using DocumentVerificationSystem.Data;
using System;

namespace DocumentVerificationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for your models
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<VerificationLog> VerificationLogs { get; set; }

        // Fluent API to configure relationships, if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            SeedData(modelBuilder);

            // Example relationship configurations:
            modelBuilder.Entity<User>()
                .HasMany(u => u.Documents)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<Document>()
                .HasMany(d => d.VerificationLogs)
                .WithOne(v => v.Document)
                .HasForeignKey(v => v.DocumentId);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            DateTime currentTime = new DateTime(2023, 1, 1); 

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com", Password = "password123", Role = "Admin" },
                new User { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", Password = "password456", Role = "User" },
                new User { Id = 3, Name = "Michael Johnson", Email = "michael.johnson@example.com", Password = "password789", Role = "User" },
                new User { Id = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "password101", Role = "User" },
                new User { Id = 5, Name = "David Brown", Email = "david.brown@example.com", Password = "password202", Role = "Admin" },
                new User { Id = 6, Name = "Sarah Wilson", Email = "sarah.wilson@example.com", Password = "password303", Role = "User" }
            );

            // Seeding Documents
            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, UserId = 1, Title = "Official Document 1", FilePath = "/files/doc1.pdf", VerificationCode = "ABCD1234", Status = "Verified", CreatedAt = currentTime },
                new Document { Id = 2, UserId = 2, Title = "Official Document 2", FilePath = "/files/doc2.pdf", VerificationCode = "EFGH5678", Status = "Pending", CreatedAt = currentTime },
                new Document { Id = 3, UserId = 3, Title = "Official Document 3", FilePath = "/files/doc3.pdf", VerificationCode = "IJKL9101", Status = "Pending", CreatedAt = currentTime.AddDays(-5) },
                new Document { Id = 4, UserId = 4, Title = "Official Document 4", FilePath = "/files/doc4.pdf", VerificationCode = "MNOP1122", Status = "Verified", CreatedAt = currentTime.AddDays(-10) },
                new Document { Id = 5, UserId = 5, Title = "Official Document 5", FilePath = "/files/doc5.pdf", VerificationCode = "QRST2233", Status = "Verified", CreatedAt = currentTime.AddDays(-2) },
                new Document { Id = 6, UserId = 6, Title = "Official Document 6", FilePath = "/files/doc6.pdf", VerificationCode = "UVWX3344", Status = "Pending", CreatedAt = currentTime.AddDays(-1) }
            );

            // Seeding Verification Logs
            modelBuilder.Entity<VerificationLog>().HasData(
                new VerificationLog { Id = 1, DocumentId = 1, VerifiedBy = "Admin", Timestamp = currentTime, Status = "Verified" },
                new VerificationLog { Id = 2, DocumentId = 4, VerifiedBy = "Admin", Timestamp = currentTime.AddDays(-10), Status = "Verified" },
                new VerificationLog { Id = 3, DocumentId = 5, VerifiedBy = "Admin", Timestamp = currentTime.AddDays(-2), Status = "Verified" },
                new VerificationLog { Id = 4, DocumentId = 2, VerifiedBy = "Admin", Timestamp = currentTime.AddDays(-5), Status = "Pending" },
                new VerificationLog { Id = 5, DocumentId = 6, VerifiedBy = "User", Timestamp = currentTime.AddDays(-1), Status = "Pending" },
                new VerificationLog { Id = 6, DocumentId = 3, VerifiedBy = "Admin", Timestamp = currentTime.AddDays(-6), Status = "Pending" }
            );
        }
    }
}
