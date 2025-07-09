namespace KidycareBackend.Profiles.Domain.Model.ValueObjects;

public record EmailAddress(string Address)
{
    public EmailAddress(): this(String.Empty){ }
};