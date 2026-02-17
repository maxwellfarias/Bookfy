namespace Bookfy.Domain.Apartments;


//A record is a good choice for the Address class because it is a simple data structure that is primarily used to hold data. Records are
//immutable by default, which means that once an instance of the Address record is created, its properties cannot be changed. This immutability can
//help prevent bugs and make the code easier to reason about, especially when dealing with value objects like addresses. Additionally, records provide
//built-in support for value-based equality, which means that two instances of the Address record with the same property values will be considered equal.
//This can be useful when comparing addresses or using them as keys in collections.
public record Address(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street
);


