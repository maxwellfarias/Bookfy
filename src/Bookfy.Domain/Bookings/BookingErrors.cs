using System;
using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings;

public static class BookingErrors
{
    public static readonly Error NotFound = new(
        "Booking.NotFound",
        "The booking with the specified identifier was not found."
    );
    public static readonly Error Overlapping = new(
        "Booking.Overlap",
        "The current booking is overlapping with an existing one."
    );
    public static readonly Error NotReserved = new(
        "Booking.NotReserved",
        "The booking is not reserved."
    );
    public static readonly Error NotConfirmed = new(
        "Booking.NotConfirmed",
        "The booking is not confirmed."
    );
    public static readonly Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "The booking has already started."
    );
    public static readonly Error NotPending = new(
        "Booking.NotPending",
        "The booking is not pending."
    );
}
