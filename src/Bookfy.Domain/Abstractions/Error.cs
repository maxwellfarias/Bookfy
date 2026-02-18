namespace Bookify.Domain.Abstractions;

public record class Error(string Code, string Message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Null value was provided");
}
