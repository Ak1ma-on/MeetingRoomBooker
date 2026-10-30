using MeetingRoomBooker.Domain.Interfaces;

namespace MeetingRoomBooker.Tests
{
    internal class Clock : IClock
    {
        public DateTime Now { get; }

        public Clock(DateTime datetime)
        {
            Now = datetime;
        }
    }
}
