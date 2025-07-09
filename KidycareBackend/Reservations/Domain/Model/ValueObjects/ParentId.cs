namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record ParentId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(ParentId id) => id.Value;
    public static implicit operator ParentId(int value) => new(value);
};