using Fibonacci_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Fibonacci_api.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("YourSqlServerConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Company);
                entity.Property(e => e.ProfileImage);
                entity.Property(e => e.Email);
                entity.Property(e => e.Birthdate);
                entity.Property(e => e.WorkPhoneNumber);
                entity.Property(e => e.PersonalPhoneNumber);
                entity.Property(e => e.Address);
                entity.Property(e => e.City);
                entity.Property(e => e.State);
            });
        }
    }
}
