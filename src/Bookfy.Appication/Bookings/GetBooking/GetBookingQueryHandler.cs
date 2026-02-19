using System;
using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public Task<Domain.Abstractions.Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
