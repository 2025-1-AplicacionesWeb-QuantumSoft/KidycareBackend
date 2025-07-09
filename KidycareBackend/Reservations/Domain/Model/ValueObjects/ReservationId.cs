namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record ReservationId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(ReservationId id) => id.Value;
    public static implicit operator ReservationId(int value) => new(value);
};