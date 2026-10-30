# MeetingRoomBooker

A backend application for managing meeting room reservations.

MeetingRoomBooker allows users to register meeting rooms, create bookings, and find available rooms for a specific time interval.

The project is built with **ASP.NET Core** and follows **Clean Architecture** principles, with a clear separation between business logic, application services, and infrastructure.

## Features

- **Room Management** - register new meeting rooms.
- **Room Availability** - find rooms available during a specified time interval.
- **Booking Management** - create meeting room reservations.
- **Booking Validation** - prevent invalid booking intervals and bookings in the past.
- **Conflict Detection** - prevent overlapping bookings for the same room.

## Tech Stack

- **C#**
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **xUnit** — unit testing

## Architecture

The solution follows Clean Architecture principles and is divided into four main projects:

| Project | Responsibility |
|---|---|
| `MeetingRoomBooker.Domain` | Core business entities, interfaces, and business rules |
| `MeetingRoomBooker.Application` | Application services and use-case orchestration |
| `MeetingRoomBooker.Infrastructure` | Database access and external dependencies |
| `MeetingRoomBooker.API` | HTTP endpoints, dependency injection, and application entry point |

The architecture aims to keep business logic independent of infrastructure and presentation concerns.

## Project Structure

```text
MeetingRoomBooker/
├── MeetingRoomBooker.Domain/
├── MeetingRoomBooker.Application/
├── MeetingRoomBooker.Infrastructure/
├── MeetingRoomBooker.API/
└── MeetingRoomBooker.Tests/
```

## Getting Started

### Prerequisites

- .NET 8 SDK

### Installation

1. Clone the repository:

```bash
git clone https://github.com/Ak1ma-on/MeetingRoomBooker.git
cd MeetingRoomBooker
```

2. Build the solution:

```bash
dotnet build
```

3. Run the API:

```bash
dotnet run --project MeetingRoomBooker.API
```

*Database configuration and migrations may need to be applied before running the application.*

## Testing

Run the unit tests using:

```bash
dotnet test
```

The test project uses xUnit to verify domain behavior, including booking creation and validation.

## Project Status

This project is being developed as a practical backend engineering portfolio project.
