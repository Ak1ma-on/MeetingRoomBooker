using MeetingRoomBooker.Application.Services;
using MeetingRoomBooker.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost("book/{roomNumber}")]
        [EndpointName("Add Booking")]
        public async Task<IActionResult> AddBooking(int roomNumber, [FromBody] AddBookingRequest request)
        {
            var result = await bookingService.AddBookingAsync(roomNumber, request.Start, request.End);
            if (result == Application.OperationResults.AddBookingResult.BookingHasOverlap) return BadRequest("Booking has overlap");
            if (result == Application.OperationResults.AddBookingResult.IncorrectTimeSpan) return BadRequest("Incorrect time span");
            if (result == Application.OperationResults.AddBookingResult.IncorrectRoomNumber) return BadRequest("Incorrect room number");
            if (result == Application.OperationResults.AddBookingResult.RoomHasNotFound) return NotFound("Room has been not found");

            return Created();
        }
    }
}
