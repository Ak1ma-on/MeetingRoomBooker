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
            return !await context.Bookings
                .Where(b => b.RoomId == newBooking.RoomId)
                .AnyAsync(b => b.BookEnd < newBooking.BookStart
                || b.BookStart > newBooking.BookEnd);
        }
    }
}
