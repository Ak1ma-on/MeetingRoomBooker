using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Application.OperationResults;
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

        public async Task<RegisterRoomResult> RegisterRoomAsync(int number)
        {
            if (number <= 0) return RegisterRoomResult.InvalidNumber;

            var existingRoom = await roomRepository.GetByNumberAsync(number);

            if (existingRoom is not null) return RegisterRoomResult.RoomAlreadyExists;

            Room room = new Room(number);

            if (!await roomRepository.AddRoomAsync(room))
            {
                return RegisterRoomResult.RoomAlreadyExists;
            }

            return RegisterRoomResult.Success;
        }

        public async Task<IReadOnlyCollection<Room>> GetFreeRoomsAsync(DateTime start, DateTime end)
        {
            if (start >= end) throw new ArgumentException("Incorrect timespan");

            return await roomRepository.GetFreeRoomsAsync(start, end);
        }
    }
}
