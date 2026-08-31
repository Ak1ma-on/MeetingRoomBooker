using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Application.Interfaces
{
    public interface IBookingRepository
    {
        public Task AddBookingAsync(Booking booking);
        public Task<bool> HasOverlapAsync(Booking booking);
    }
}
