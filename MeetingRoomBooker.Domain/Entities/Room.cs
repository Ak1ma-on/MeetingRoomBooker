namespace MeetingRoomBooker.Domain.Entities
{
    public class Room
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public ICollection<Booking> Bookings { get; private set; } = [];

        public Room(int number)
        {
            Number = number;
        }
    }
}
