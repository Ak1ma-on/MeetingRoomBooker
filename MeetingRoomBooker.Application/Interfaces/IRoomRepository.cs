using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Application.Interfaces
{
    public interface IRoomRepository
    {
        public Task<IReadOnlyCollection<Room>> GetFreeRoomsAsync(DateTime start, DateTime end);
        public Task<bool> AddRoomAsync(Room room);
        public Task<Room?> GetByNumberAsync(int number);
    }
}
