using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository repository)
        {
            roomRepository = repository;
        }

        public async Task RegisterRoomAsync(int number)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException($"Incorrect number of room: {nameof(number)}");

            Room room = new Room(number);
            await roomRepository.AddRoomAsync(room);
        }

        public async Task<IReadOnlyList<Room>> GetFreeRoomsAsync(DateTime start, DateTime end)
        {
            if (start >= end) throw new ArgumentException("Incorrect timespan");

            return await roomRepository.GetFreeRoomsAsync(start, end);
        }
    }
}
