using System;

namespace Bookfy.Domain;
// The Entity class is an abstract class that represents a base entity in the domain. It has a single property,
// Id, which is a unique identifier for the entity.
public abstract class Entity
{
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

}
