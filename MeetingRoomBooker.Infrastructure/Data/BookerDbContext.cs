using MeetingRoomBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MeetingRoomBooker.Infrastructure.Data
{
    public class BookerDbContext : DbContext
    {        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasIndex(r => r.Number).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine("..", "MeetingRoomBooker.Infrastructure", "booker.db");
            optionsBuilder.UseSqlite($"Data source={dbPath}");
        }
    }
}
