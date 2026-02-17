namespace Bookfy.Domain.Apartments;

public record class Money(decimal Amount, Currency Currency)
{
    /*
    Operator overloading allows us to define how the + operator works for the Money class. In this case, we check if the currencies of the two Money
    instances are the same before performing the addition. If they are not the same, we throw an exception. If they are the same, we create a new Money
    instance with the sum of the amounts and the same currency.
    */
   public static Money operator +(Money first, Money second)
   {
       if (first.Currency != second.Currency)
       {
           throw new InvalidOperationException("Currencies must be the same to perform addition.");
       }
       return new Money(first.Amount + second.Amount, first.Currency);
   }

   public static Money Zero() => new(0, Currency.None);
   public static Money Zero(Currency currency) => new(0, currency);
   public bool IsZero() => this == Zero(Currency);
}
