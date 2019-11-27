using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Visitors> Visitors { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasKey(key => key.Login);
            modelBuilder.Entity<Room>().HasKey(key => key.Number);
            modelBuilder.Entity<Customer>().HasKey(key => key.Phone);
            modelBuilder.Entity<Visitors>().HasKey(key => key.Record);
            
            modelBuilder.Entity<Visitors>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.Phone)
                .OnDelete(DeleteBehavior.Restrict);
           
            modelBuilder.Entity<Visitors>()
                .HasOne(c => c.Room)
                .WithMany()
                .HasForeignKey(c => c.Number)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
