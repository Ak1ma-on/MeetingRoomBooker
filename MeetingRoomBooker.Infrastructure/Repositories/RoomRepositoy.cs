using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Infrastructure.Repositories
{
    public class RoomRepositoy : IRoomRepository
    {
        public async Task<Room> GetByNumberAsync(int number)
        {

        }
    }
}
