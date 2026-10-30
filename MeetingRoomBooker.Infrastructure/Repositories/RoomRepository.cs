using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;
using MeetingRoomBooker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooker.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookerDbContext context;
        public RoomRepository(BookerDbContext context)
        {
            this.context = context;
        }

        public async Task<Room?> GetByNumberAsync(int number)
        {
            Room? room = await context.Rooms.SingleOrDefaultAsync(r => r.Number == number);

            if (room is null) return null;

            return room;
        }

        public async Task<IReadOnlyCollection<Room>> GetFreeRoomsAsync(DateTime start, DateTime end)
        {
            return await context.Rooms
                .Include(r => r.Bookings)
                .Where(r => !r.Bookings.Any(b => b.BookStart < end && b.BookEnd > start))
                .ToListAsync();
        }

        public async Task<bool> AddRoomAsync(Room room)
        {
            try
            {
                await context.Rooms.AddAsync(room);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
