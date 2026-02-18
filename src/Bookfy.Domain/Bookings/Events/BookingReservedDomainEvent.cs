using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings.Events;

public record class BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
