using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;
using MeetingRoomBooker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooker.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookerDbContext context;
        public BookingRepository(BookerDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await context.Bookings.AddAsync(booking);
            await context.SaveChangesAsync();
        }

        public async Task<bool> HasOverlapAsync(Booking booking)
        {
            Room? room = await context.Rooms.SingleOrDefaultAsync(r => r.Id == booking.RoomId);

            List<Booking> conflictBookings = context.Bookings
                .Where(b => b.BookStart >= booking.BookStart && b.BookStart <= booking.BookEnd || b.BookEnd >= booking.BookStart && b.BookEnd <= booking.BookEnd).ToList();

            return conflictBookings.Count != 0;
        }
    }
}
