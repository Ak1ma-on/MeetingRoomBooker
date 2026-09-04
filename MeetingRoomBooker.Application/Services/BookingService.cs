using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;
using MeetingRoomBooker.Domain.Interfaces;
using MeetingRoomBooker.Application.OperationResults;

namespace MeetingRoomBooker.Application.Services
{
    public class BookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IClock clock;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository, IClock clock)
        {
            this.bookingRepository = bookingRepository;
            this.roomRepository = roomRepository;
            this.clock = clock;
        }

        public async Task<AddBookingResult> AddBookingAsync(int roomNumber, DateTime start, DateTime end)
        {
            if (start > end) return AddBookingResult.IncorrectTimeSpan;
            if (roomNumber <= 0) return AddBookingResult.IncorrectRoomNumber;

            Room room = roomRepository.GetByNumber(roomNumber).Room;
            if (room is null) return AddBookingResult.RoomHasNotFound;

            Booking booking = new Booking(room.Id, start, end, clock);
            await bookingRepository.AddBookingAsync(booking);
            return AddBookingResult.Success;
        }
    }
}
