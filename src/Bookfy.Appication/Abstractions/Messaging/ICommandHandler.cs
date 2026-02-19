using System;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

/// <summary>
/// Defines a handler for commands that do not return a response value.
/// This interface is used for command handlers that perform side effects or state changes
/// but don't need to return any specific result data to the caller beyond success/failure status.
/// </summary>
/// <typeparam name="TCommand">
/// The type of command this handler processes. Must implement the <see cref="ICommand"/> interface.
/// This type parameter specifies what kind of command request this handler can process.
/// </typeparam>
///
/// <remarks>
/// <para>
/// This interface inherits from MediatR's <see cref="IRequestHandler{TRequest, TResponse}"/>,
/// where the response is a <see cref="Result"/> object containing only success/failure information.
/// </para>
///
/// <para>
/// <strong>Usage Example:</strong><br/>
/// Implement this interface for commands that perform actions but don't return specific data.
/// For example, a handler that cancels a booking would not need to return booking details.
/// </para>
///
/// <para>
/// <code>
/// public class CancelBookingCommandHandler : ICommandHandler&lt;CancelBookingCommand&gt;
/// {
///     public async Task&lt;Result&gt; Handle(CancelBookingCommand request, CancellationToken cancellationToken)
///     {
///         // Perform the cancellation logic
///         // Return Result.Success() if successful
///         // Return Result.Failure(error) if failed
///     }
/// }
///
/// // Usage in application service:
/// var command = new CancelBookingCommand(bookingId);
/// Result result = await mediator.Send(command);
/// if (result.IsSuccess)
/// {
///     // Booking cancelled successfully
/// }
/// </code>
/// </para>
/// </remarks>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand { }

/// <summary>
/// Defines a handler for commands that return a response value of a specific type.
/// This interface is used for command handlers that perform operations and need to return
/// domain-specific data back to the caller (e.g., the ID of a created resource).
/// </summary>
/// <typeparam name="TCommand">
/// The type of command this handler processes. Must implement the <see cref="ICommand{TResponse}"/> interface.
/// This generic parameter specifies the shape of the command request that this handler accepts.
/// </typeparam>
/// <typeparam name="TResponse">
/// The type of response data returned by this handler. This is the actual business domain data
/// that the command execution produces (e.g., a booking ID, a user object, etc.).
/// </typeparam>
///
/// <remarks>
/// <para>
/// This interface inherits from MediatR's <see cref="IRequestHandler{TRequest, TResponse}"/>,
/// where the response is a <see cref="Result{T}"/> generic object containing either the successful
/// result data of type <typeparamref name="TResponse"/> or failure information.
/// </para>
///
/// <para>
/// <strong>Usage Example:</strong><br/>
/// Implement this interface for commands that perform actions and need to return
/// the result of that action. For example, a handler that creates a booking should
/// return the newly created booking's ID or the booking object itself.
/// </para>
///
/// <para>
/// <code>
/// public class ReserveBookingCommandHandler : ICommandHandler&lt;ReserveBookingCommand, Guid&gt;
/// {
///     public async Task&lt;Result&lt;Guid&gt;&gt; Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
///     {
///         // Create and save the booking
///         var booking = new Booking(...);
///         await _bookingRepository.AddAsync(booking);
///         await _unitOfWork.SaveChangesAsync();
///
///         // Return the booking ID
///         return Result.Success(booking.Id);
///     }
/// }
///
/// // Usage in application service:
/// var command = new ReserveBookingCommand(apartmentId, userId, checkIn, checkOut);
/// Result&lt;Guid&gt; result = await mediator.Send(command);
/// if (result.IsSuccess)
/// {
///     var bookingId = result.Value; // Access the returned booking ID
///     // Continue with next step using the booking ID
/// }
/// </code>
/// </para>
/// </remarks>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse> { }
