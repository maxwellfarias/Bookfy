using System;
using System.Windows.Input;
using Bookfy.Domain.Abstractions;
using Bookfy.Domain.Apartments;
using Bookfy.Domain.Bookings;
using Bookfy.Domain.Users;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;

namespace Bookify.Application.Bookings;

public sealed class ReserveBookingCommandHandler(
    IUserRepository userRepository,
    IApartmentRepository apartmentRepository,
    IBookingRepository bookingRepository,
    IUnitOfWork unitOfWork,
    PricingService pricingService
) : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IBookingRepository _bookingRepository = bookingRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly PricingService _pricingService = pricingService;

    public async Task<Result<Guid>> Handle(
        ReserveBookingCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        throw new NotImplementedException();
    }
}
