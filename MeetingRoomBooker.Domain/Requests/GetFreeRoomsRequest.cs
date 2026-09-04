namespace MeetingRoomBooker.Domain.Requests
{
    public class GetFreeRoomsRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
