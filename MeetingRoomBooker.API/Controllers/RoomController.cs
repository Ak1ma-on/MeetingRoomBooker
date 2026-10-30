using MeetingRoomBooker.Application.Services;
using MeetingRoomBooker.Application.OperationResults;
using MeetingRoomBooker.Domain.Requests;
using MeetingRoomBooker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost("register/{number}")]
        public async Task<IActionResult> RegisterRoomAsync(int number)
        {
            var result = await roomService.RegisterRoomAsync(number);
            if (result == RegisterRoomResult.InvalidNumber) return BadRequest("Invalud number of room");
            if (result == RegisterRoomResult.RoomAlreadyExists) return BadRequest("Room with this number already exists");
            return NoContent();
        }

        [HttpPost("free")]        
        public async Task<ActionResult<List<Room>>> GetFreeRoomsAsync([FromBody] GetFreeRoomsRequest timeSpan)
        {
            var freeRooms = await roomService.GetFreeRoomsAsync(timeSpan.Start, timeSpan.End);
            return Ok(freeRooms);
        }
    }
}
