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

        [HttpPost("{number}")]
        public IActionResult RegisterRoom(int number)
        {
            var result = roomService.RegisterRoom(number);
            if (result == RegisterRoomResult.InvalidNumber) return BadRequest("Invalud number of room");
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Room>> GetFreeRooms([FromBody] GetFreeRoomsRequest timeSpan)
        {
            var freeRooms = roomService.GetFreeRooms(timeSpan.Start, timeSpan.End);
            return Ok(freeRooms);
        }
    }
}
