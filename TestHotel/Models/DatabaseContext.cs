using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clietns { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasKey(key => key.Id);
            modelBuilder.Entity<Client>().HasKey(key => key.Id);
            modelBuilder.Entity<Visit>().HasKey(key => key.Id);
            modelBuilder.Entity<RoomType>().HasKey(key => key.Id);
            modelBuilder.Entity<State>().HasKey(key => key.Id);

            modelBuilder.Entity<Visit>()
                .HasOne(c => c.Client)
                .WithMany(c=>c.Visits)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
               .HasOne(c => c.Type)
               .WithMany(c=>c.Rooms)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
              .HasOne(s => s.State)
              .WithMany(s=>s.Rooms)
              .HasForeignKey(c => c.StateId)
              .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
