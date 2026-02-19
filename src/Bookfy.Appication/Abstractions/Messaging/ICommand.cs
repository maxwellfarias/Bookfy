using System;
using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

/// <summary>
/// Marker interface that serves as the base contract for all command implementations.
/// This interface is used to identify types that represent commands in the application.
/// Commands represent an intent to perform an action or operation that modifies application state.
/// </summary>
/// <remarks>
/// This is a marker interface with no members. It's used in the type system and dependency injection
/// to identify and filter command types at runtime. All command interfaces should inherit from this
/// to ensure they are recognized by the application's command handling infrastructure.
/// </remarks>
public interface IBaseCommand { }

/// <summary>
/// Represents a command that does not return a response value.
/// This interface is used for fire-and-forget operations or commands that only need to indicate success/failure.
/// Implements MediatR's IRequest pattern for command handling via the Mediator pattern.
/// </summary>
/// <remarks>
/// <para>
/// When to use ICommand:
/// - For commands that modify state but don't need to return specific data
/// - For operations where only the success or failure status matters
/// - For integration with MediatR request/response pipeline
/// </para>
/// <para>
/// How to use:
/// 1. Create a class that implements ICommand
/// 2. Add properties for command parameters (e.g., booking details, user information)
/// 3. Create a corresponding ICommandHandler&lt;YourCommand&gt; to handle the command execution
/// 4. Register both in dependency injection
/// 5. Use MediatR's mediator.Send() to execute the command
/// </para>
/// <para>
/// Example:
/// <code>
/// public class ReserveBookingCommand : ICommand
/// {
///     public Guid ApartmentId { get; init; }
///     public Guid UserId { get; init; }
///     public DateRange DateRange { get; init; }
/// }
///
/// // Handler
/// public class ReserveBookingCommandHandler : ICommandHandler&lt;ReserveBookingCommand&gt;
/// {
///     public async Task&lt;Result&gt; Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
///     {
///         // Implementation here
///         return Result.Success();
///     }
/// }
///
/// // Usage
/// var command = new ReserveBookingCommand { ApartmentId = id, UserId = userId, DateRange = range };
/// var result = await mediator.Send(command);
/// </code>
/// </para>
/// </remarks>
public interface ICommand : IRequest<Result>, IBaseCommand { }

/// <summary>
/// Represents a command that returns a typed response of TResponse.
/// This interface is used when commands need to return specific data after execution.
/// Implements MediatR's generic IRequest pattern for type-safe command handling.
/// </summary>
/// <typeparam name="TResponse">
/// The type of data that will be returned when the command is successfully executed.
/// This allows the command to communicate results back to the caller with strong typing.
/// </typeparam>
/// <remarks>
/// <para>
/// When to use ICommand&lt;TResponse&gt;:
/// - For commands that need to return a specific result value
/// - When the caller needs typed data back from the command execution
/// - For operations that create or retrieve entities and need to return them
/// - For commands with complex return types (DTOs, aggregates, etc.)
/// </para>
/// <para>
/// How to use:
/// 1. Create a class implementing ICommand&lt;TResponse&gt; where TResponse is your return type
/// 2. Add properties for input parameters
/// 3. Create a handler implementing ICommandHandler&lt;YourCommand, TResponse&gt;
/// 4. In the handler's Handle method, return Result&lt;TResponse&gt; with the data
/// 5. Use MediatR's mediator.Send() to execute
/// 6. The result will contain strongly-typed success data or error information
/// </para>
/// <para>
/// Example:
/// <code>
/// public class CreateUserCommand : ICommand&lt;UserDto&gt;
/// {
///     public string Email { get; init; }
///     public string FirstName { get; init; }
///     public string LastName { get; init; }
/// }
///
/// // Handler
/// public class CreateUserCommandHandler : ICommandHandler&lt;CreateUserCommand, UserDto&gt;
/// {
///     public async Task&lt;Result&lt;UserDto&gt;&gt; Handle(CreateUserCommand request, CancellationToken cancellationToken)
///     {
///         var user = new User(request.Email, request.FirstName, request.LastName);
///         // Save user...
///         var dto = new UserDto { Email = user.Email, Name = user.Name };
///         return Result&lt;UserDto&gt;.Success(dto);
///     }
/// }
///
/// // Usage
/// var command = new CreateUserCommand { Email = "user@example.com", FirstName = "John", LastName = "Doe" };
/// var result = await mediator.Send(command);
/// if (result.IsSuccess)
/// {
///     var createdUser = result.Value; // UserDto with the created user's data
/// }
/// </code>
/// </para>
/// </remarks>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }
