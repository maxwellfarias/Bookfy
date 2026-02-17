using System;
using Bookfy.Domain.Apartments;

namespace Bookfy.Domain.Bookings;

public class PricingService
{
     public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
     {
        var currency = apartment.Price.Currency;
        var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);
        decimal percentageUpCharge = 0;
        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0
            };
        }
        var amentitiesUpCharge = Money.Zero(currency);
        //calculate up charge for amenities if there are any
        if (percentageUpCharge > 0)
        {
            amentitiesUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
        }
        var totalPrice = Money.Zero();
        totalPrice += priceForPeriod;
        //Add cleaning fee if there is any
        if(!apartment.CleaningFee.IsZero())
        {       
            totalPrice += apartment.CleaningFee;
        }
        totalPrice += amentitiesUpCharge;
        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amentitiesUpCharge, totalPrice);
     }
}
