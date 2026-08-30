namespace MeetingRoomBooker.Domain.Interfaces
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
