using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings.Events;

public record class BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
