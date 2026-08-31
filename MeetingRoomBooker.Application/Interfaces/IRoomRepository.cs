using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Application.Interfaces
{
    public interface IRoomRepository
    {
        public Task<IReadOnlyList<Room>> GetFreeRoomsAsync(DateTime start, DateTime end);
        public Task AddRoomAsync(Room room);
        public Task<Room> GetByNumberAsync(int number);
    }
}
