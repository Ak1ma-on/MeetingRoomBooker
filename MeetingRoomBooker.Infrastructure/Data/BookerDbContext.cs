using MeetingRoomBooker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooker.Infrastructure.Data
{
    public class BookerDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine("..", "MeetingRoomBooker.Infrastructure", "booker.db");
            optionsBuilder.UseSqlite($"Data source={dbPath}");
        }
    }
}
