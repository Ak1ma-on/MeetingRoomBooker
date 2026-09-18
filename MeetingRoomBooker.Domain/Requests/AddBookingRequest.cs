namespace MeetingRoomBooker.Domain.Requests
{
    public class AddBookingRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
