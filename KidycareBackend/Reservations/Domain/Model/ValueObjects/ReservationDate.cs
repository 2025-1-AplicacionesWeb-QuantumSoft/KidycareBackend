namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record ReservationDate(DateTime Value)
{
    public ReservationDate() : this(DateTime.UtcNow)
    {
        if (Value == default)
            throw new ArgumentException("Date cannot be empty");
    }

    public override string ToString() => Value.ToString("o");

    public static implicit operator DateTime(ReservationDate d) => d.Value;
    public static implicit operator ReservationDate(DateTime d) => new(d);
}