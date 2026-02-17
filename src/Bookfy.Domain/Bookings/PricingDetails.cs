using Bookfy.Domain.Apartments;

namespace Bookfy.Domain.Bookings;

public record class PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);