using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OccupationalTherapist_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccessLayer.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public const string ConnectionString = "ErgApp";
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // IdentityUserLogin için anahtar belirleniyor
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<Comment>()
        .HasOne(c => c.Post)
        .WithMany(p => p.Comment)
        .HasForeignKey(c => c.PostId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                });

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "admin@mail.com",
                    FirstName = "Admin1",
                    LastName = "Admin1",
                    Email = "admin@mail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin+123")
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1",
                });
        }

    }
}
