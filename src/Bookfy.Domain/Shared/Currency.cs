namespace Bookfy.Domain.Apartments;

public record class Currency
{
    /*
    The internal key word means that the None currency can only be accessed within the same assembly, which is useful for preventing external code from
    using it directly. The static readonly modifier means that the None currency is a constant value that cannot be changed after it is initialized.
    By defining a None currency, we can represent situations where there is no valid currency or when we want to initialize a Money instance with a
    default value that does not have a valid currency.
   None:  allows us to define a special currency called None, which can be used to represent the absence of a currency. This is useful in cases
    where we want to indicate that a certain amount of money does not have an associated currency, or when we want to initialize a Money instance
    with a default value that does not have a valid currency.
    */
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");

    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c =>
                c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase)
            ) ?? throw new ArgumentException($"Invalid currency code: {code}");
    }

    public static readonly IReadOnlyCollection<Currency> All = [Usd, Eur];
}
