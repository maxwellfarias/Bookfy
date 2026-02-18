using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
