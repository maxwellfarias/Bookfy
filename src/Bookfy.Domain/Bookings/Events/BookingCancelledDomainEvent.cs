using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings.Events;

public record class BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
