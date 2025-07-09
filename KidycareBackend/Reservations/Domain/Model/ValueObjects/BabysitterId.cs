namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record BabysitterId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(BabysitterId id) => id.Value;
    public static implicit operator BabysitterId(int value) => new(value);
};