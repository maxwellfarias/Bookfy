using System.Windows.Input;
using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings;

public record class ReserveBookingCommand(
    Guid ApartamentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
) : ICommand<Guid>;
