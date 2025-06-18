using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Aggregates;

public class Reservation
{
    public int Id { get; private set; }
    public BabysitterId BabysitterId { get; private set; }
    public ParentId ParentId { get; private set; }
    public ReservationDate StartTime { get; private set; }
    public ReservationDate EndTime { get; private set; }
    public ReservationStatus Status { get; private set; }
    public NotificationId NotificationId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Reservation() {}

    public Reservation(CreateReservationCommand command)
    { 
        BabysitterId = command.BabysitterId;
        ParentId = command.ParentId;
        StartTime = command.StartTime;
        EndTime = command.EndTime;
        Status = ReservationStatus.Pending;
        NotificationId = command.NotificationId;
        CreatedAt = DateTime.UtcNow;
    }

    public void Confirm() => Status.TransitionTo("CONFIRMED");
    public void Cancel() => Status.TransitionTo("CANCELED");
}