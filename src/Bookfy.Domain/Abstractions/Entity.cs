using System;
using Bookfy.Domain.Abstractions;

namespace Bookfy.Domain.Abstractions;

// The Entity class is an abstract class that represents a base entity in the domain. It has a single property,
// Id, which is a unique identifier for the entity.
public abstract class Entity
{
    // The _domainEvents field is a private list that holds the domain events that have occurred for this entity.
    private readonly List<IDomainEvent> _domainEvents = [];

    // The constructor is protected, which means that it can only be called by derived classes. This is because the Entity class is abstract and
    // cannot be instantiated directly.
    protected Entity(Guid id)
    {
        Id = id;
    }

    // init means that the property can only be set during object initialization. This is useful for properties
    // that should not change after the object has been created, such as an Id property that uniquely
    // identifies the entity. By using init, we can ensure that the Id is set when the entity is created
    // and cannot be modified later on, which helps maintain the integrity of the entity.
    public Guid Id { get; init; }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
