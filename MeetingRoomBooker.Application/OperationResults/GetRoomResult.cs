using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Infrastructure.OperationResults
{
    public class GetRoomResult
    {
        public Room Room { get; set; } = null!;
        public Status Status { get; set; }
    }

    public enum Status
    {
        Success,
        NotFound
    }
}
