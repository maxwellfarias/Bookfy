using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings.Events;

public record class BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;