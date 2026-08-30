using MeetingRoomBooker.Domain.Interfaces;

namespace MeetingRoomBooker.Domain.Entities
{
    public class Booking
    {
        public int Id { get; private set; }
        public int RoomId { get; private set; } 
        public DateTime BookStart { get; private set; }
        public DateTime BookEnd { get; private set; }

        public Booking(int roomId, DateTime bookStart, DateTime bookEnd, IClock clock)
        {
            DateTime now = clock.Now;
            if (bookStart >= bookEnd) throw new ArgumentException("Start of booking must be earlier than its end");
            if (bookStart < now) throw new ArgumentException("Room cannot be booked earlier than now");

            RoomId = roomId;
            BookStart = bookStart;
            BookEnd = bookEnd;
        }

        public BookingStatus GetStatus(IClock clock)
        {
            var now = clock.Now;

            if (now < BookStart) return BookingStatus.Ahead;
            else if (now >= BookStart && now < BookEnd) return BookingStatus.Active;
            else return BookingStatus.Ended;
        }
    }
}
