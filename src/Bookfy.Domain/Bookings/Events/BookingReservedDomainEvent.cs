using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
