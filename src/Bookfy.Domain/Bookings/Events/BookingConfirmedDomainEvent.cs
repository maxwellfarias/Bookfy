using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Bookings.Events;

public record class BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
