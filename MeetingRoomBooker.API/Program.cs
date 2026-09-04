using MeetingRoomBooker.API;
using MeetingRoomBooker.Application.Interfaces;
using MeetingRoomBooker.Application.Services;
using MeetingRoomBooker.Domain.Interfaces;
using MeetingRoomBooker.Infrastructure.Data;
using MeetingRoomBooker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<BookerDbContext>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddSingleton<IClock, Clock>();

var app = builder.Build();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
