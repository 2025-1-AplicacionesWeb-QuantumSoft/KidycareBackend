namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record NotificationId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(NotificationId id) => id.Value;
    public static implicit operator NotificationId(int value) => new(value);
};