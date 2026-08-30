namespace MeetingRoomBooker.Domain.Entities
{
    public class Room
    {
        public int Id { get; private set; }
        public ICollection<Booking> Bookings { get; private set; } = [];
    }
}
