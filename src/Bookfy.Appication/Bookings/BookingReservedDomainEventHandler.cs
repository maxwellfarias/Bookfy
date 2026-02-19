using System;
using Bookify.Application.Abstractions.Mail;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Domain.Bookings;

internal sealed class BookingReservedDomainEventHandler(
    IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService) : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailService _emailService = emailService;

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        if (booking is null)
        {
            return;
        }
        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user is null)        {
            return;
        }
        await _emailService.SendAsync(
            user.Email,
            "Booking Reserved",
            $"You have 10 minutes to complete your booking with id {booking.Id} before it expires.");
    }
}
