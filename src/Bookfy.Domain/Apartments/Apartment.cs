using System;

namespace Bookfy.Domain.Apartments;

//The use of sealed is to prevent the class from being inherited. This is useful when you want to create a class that represents a specific concept
//and you don't want it to be extended or modified by other classes. In this case, the Apartment class represents a specific concept of an apartment
//and we want to ensure that it cannot be extended or modified by other classes.
public sealed class Apartment
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public decimal PriceAmount { get; private set; }
    public string PriceCurrency { get; private set; }
    public decimal CleaningFeeAmount { get; private set; }
    public string CleaningFeeCurrency { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; } = [];
}
