using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;