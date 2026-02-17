using System;
using Bookfy.Domain.Users;
using Bookfy.Domain.Users.Events;

namespace Bookfy.Domain.Users;

public sealed class User : Entity
{
    public User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    /*
    There are some benefits to using a static factory method like Create instead of a constructor for creating instances of the User class:
1. Encapsulation: A static factory method can encapsulate the logic for creating an instance of the User class, which can help to keep the code organized
and maintainable.
2. Validation: A static factory method can perform validation on the input parameters before creating an instance of the User class. This can help to ensure
that the User object is always in a valid state.
3. Flexibility: A static factory method can return different types of objects based on the input parameters. For example, it could return a different
implementation of the User class based on the user's role or other criteria.
4. Readability: A static factory method can have a descriptive name that makes it clear what the method does, which can improve the readability of the
code.
    */

    static public User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return new User(Guid.NewGuid(), firstName, lastName, email);
    }
}

//