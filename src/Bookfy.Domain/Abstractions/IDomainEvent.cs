using System;
using MediatR;

namespace Bookfy.Domain.Abstractions;

/*
DomainEvent is a marker interface that represents an event that has occurred within the domain. It is used to indicate that a particular event
is a domain event, which can be handled by domain event handlers.

The mediatorR.Contracts namespace is part of the MediatR library, which is a popular library for implementing the mediator pattern in .NET applications.
The IDomainEvent interface is defined in the MediatR library and is used to represent domain events that can be published and handled by the mediator.
*/
public interface IDomainEvent : INotification { }
