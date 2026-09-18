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

        public async Task<bool> HasOverlapAsync(Booking newBooking)
        {
            Room? room = await context.Rooms.SingleOrDefaultAsync(r => r.Id == newBooking.RoomId);

            List<Booking> conflictBookings = context.Bookings
                .Where(b => b.BookStart >= newBooking.BookStart && b.BookStart < newBooking.BookEnd || b.BookEnd > newBooking.BookStart && b.BookEnd <= newBooking.BookEnd).ToList();

            return conflictBookings.Count != 0;
        }
    }
}
