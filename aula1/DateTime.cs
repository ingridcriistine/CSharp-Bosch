public struct DateTime
{
    readonly long ticks = 0;
    public long Ticks => ticks;

    public long Minutes => ticks / 1000 / 60 % 60;

    public DateTime() { }
    public DateTime(long ticks)
        => this.ticks = ticks;
    public DateTime(int dayOfYear, int year)
    {
        int yearsPassed = year - 1970;
        int daysPassed = dayOfYear + yearsPassed * 365;
        ticks = daysPassed * 24 * 60 * 60 * 1000;
    }

    public static TimeSpan operator -(DateTime date1, DateTime date2)
        => new TimeSpan(date1.ticks - date2.ticks);
    
    public static DateTime operator +(DateTime date, TimeSpan duration)
        => new DateTime(date.ticks + duration.Ticks);
}

public struct TimeSpan
{
    long ticks = 0;
    public long Ticks => ticks;

    public TimeSpan(long ticks)
    { 
        this.ticks = ticks;
    }

    public static TimeSpan FromHours(int hours)
        => new TimeSpan(hours * 60 * 60 * 1000);

    public static TimeSpan FromMinutes(int minutes)
        => new TimeSpan(minutes * 60 * 1000);

    public static TimeSpan FromSeconds(int seconds)
        => new TimeSpan(seconds * 1000);
}

public class Number
{
    double x;

    public static implicit operator Number(int value)
        => new Number() { x = value };
    
    public static implicit operator double(Number value)
        => value.x;
}