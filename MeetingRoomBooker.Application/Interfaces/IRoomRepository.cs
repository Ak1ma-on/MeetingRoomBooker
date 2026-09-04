using MeetingRoomBooker.Domain.Entities;
using MeetingRoomBooker.Infrastructure.OperationResults;

namespace MeetingRoomBooker.Application.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end);
        public void AddRoom(Room room);
        public GetRoomResult GetByNumber(int number);
    }
}
