using Bookfy.Domain.Apartments;

namespace Bookfy.Domain.Bookings;

public record class PricingSerive(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);