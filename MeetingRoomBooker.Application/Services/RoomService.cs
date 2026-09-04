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

        public RegisterRoomResult RegisterRoom(int number)
        {
            if (number <= 0) return RegisterRoomResult.InvalidNumber;

            Room room = new Room(number);
            roomRepository.AddRoom(room);
            return RegisterRoomResult.Success;
        }

        public IEnumerable<Room> GetFreeRooms(DateTime start, DateTime end)
        {
            if (start >= end) throw new ArgumentException("Incorrect timespan");

            return roomRepository.GetFreeRooms(start, end);
        }
    }
}
