namespace Bookfy.Domain.Bookings;

public record DateRange
{
    //private constructor to enforce the use of the factory method
    private DateRange(DateTime start, DateTime end){}
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }
    public int LengthInDays => (End.DayNumber - Start.DayNumber);
    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (end < start) throw new ArgumentException("End date must be greater than or equal to start date.");

        return new DateRange(start.ToDateTime(TimeOnly.MinValue), end.ToDateTime(TimeOnly.MinValue));
    }

}
