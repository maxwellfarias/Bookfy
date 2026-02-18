using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public record class PricingSerive(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);