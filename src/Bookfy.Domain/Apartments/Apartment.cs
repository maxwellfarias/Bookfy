using System;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

//The use of sealed is to prevent the class from being inherited. This is useful when you want to create a class that represents a specific concept
//and you don't want it to be extended or modified by other classes. In this case, the Apartment class represents a specific concept of an apartment
//and we want to ensure that it cannot be extended or modified by other classes.
public sealed class Apartment : Entity
{
    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities
    )
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    // A good candidate to a value object are the string properties such as Name and Description, as well as the Address property. These properties
    // represent values that are associated with the apartment and do not have a unique identity of their own. By making them value objects,
    // we can ensure that they are immutable and can be compared based on their values rather than their identities. This can help to simplify the
    // code and make it easier to reason about the behavior of the apartment entity.
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; } = [];
}
