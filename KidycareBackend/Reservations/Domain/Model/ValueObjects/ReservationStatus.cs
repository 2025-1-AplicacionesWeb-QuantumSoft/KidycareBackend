namespace KidycareBackend.Reservations.Domain.Model.ValueObjects;

public record ReservationStatus()
{
    public static readonly ReservationStatus Pending = new("pending");
    public static readonly ReservationStatus Confirmed = new("confirmed");
    public static readonly ReservationStatus Cancelled = new("cancelled");

    public string Value { get; }

    private ReservationStatus(string value) : this()
    {
        Value = value;
    }

    public static ReservationStatus FromString(string status)
    {
        return status.ToLower() switch
        {
            "pending" => Pending,
            "confirmed" => Confirmed,
            "cancelled" => Cancelled,
            _ => throw new ArgumentException("Invalid reservation status")
        };
    }

    public override string ToString() => Value;

    public static implicit operator string(ReservationStatus status) => status.Value;
    public static implicit operator ReservationStatus(string value) => FromString(value);

    public void TransitionTo(string confirmed)
    {
         
    }
};