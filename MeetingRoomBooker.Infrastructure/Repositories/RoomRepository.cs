using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;
using MeetingRoomBooker.Infrastructure.Data;
using MeetingRoomBooker.Infrastructure.OperationResults;
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

        public GetRoomResult GetByNumber(int number)
        {
            Room? room = context.Rooms.SingleOrDefault(r => r.Number == number);

            if (room is null) return new GetRoomResult { Status = Status.NotFound };

            return new GetRoomResult
            {
                Room = room,
                Status = Status.Success
            };
        }

        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end)
        {
            return context.Rooms
                .Include(r => r.Bookings)
                .Where(r => r.Bookings.Where(b => b.BookStart >= start && b.BookStart <= end || b.BookEnd >= start && b.BookEnd <= end) == null);
        }

        public void AddRoom(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }
    }
}
