using MeetingRoomBooker.Domain.Interfaces;

namespace MeetingRoomBooker.API
{
    public class Clock : IClock
    {
        public DateTime Now {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
