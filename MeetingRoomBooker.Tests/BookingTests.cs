using MeetingRoomBooker.Domain.Entities;

namespace MeetingRoomBooker.Tests
{
    public class BookingTests
    {
        static DateTime bookingStart = new DateTime(2026, 10, 30, 10, 0, 0).AddHours(1);
        static Clock clock = new Clock(bookingStart);

        [Fact]
        public void Booking_Correct_Construct()
        {
            Booking booking = new Booking(101, bookingStart, bookingStart.AddHours(2), clock);

            Assert.Equal(101, booking.RoomId);
            Assert.Equal(bookingStart, booking.BookStart);
            Assert.Equal(bookingStart.AddHours(2), booking.BookEnd);
        }

        [Fact]
        public void Booking_In_The_Past()
        {
            Assert.Throws<ArgumentException>(() => new Booking(101, bookingStart.AddHours(-2), bookingStart.AddHours(-1), clock));
        }

        [Fact]
        public void Booking_Incorrect_Interval()
        {
            Assert.Throws<ArgumentException>(() => new Booking(101, bookingStart.AddHours(-5), bookingStart.AddHours(-6), clock));
        }

        [Fact]
        public void Booking_Start_Equals_End()
        {
            Assert.Throws<ArgumentException>(() => new Booking(101, bookingStart.AddHours(-5), bookingStart.AddHours(-5), clock));
        }
    }
}