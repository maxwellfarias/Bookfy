using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId): IDomainEvent;
