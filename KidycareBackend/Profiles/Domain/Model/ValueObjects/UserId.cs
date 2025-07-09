namespace KidycareBackend.Profiles.Domain.Model.ValueObjects;

public record UserId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(UserId id) => id.Value;
    public static implicit operator UserId(int value) => new(value);
};