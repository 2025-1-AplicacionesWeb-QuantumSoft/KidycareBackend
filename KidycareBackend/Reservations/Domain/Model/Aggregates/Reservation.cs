using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Model.Aggregates;

public class Reservation
{
    public int Id { get; private set; }
    
    public string childName { get; private set; }
    
    public string childAge { get; private set; }
    
    public string specialNeeds { get; private set; }
    
    public string additionalInfo { get; private set; }
    
    public string address { get; private set; }
    
    public string frecuency { get; private set; }
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
        address = command.Address;
        frecuency = command.Frequency;
        childName = command.ChildName;
        childAge = command.ChildAge;
        specialNeeds = command.SpecialNeeds;
        additionalInfo = command.AdditionalInfo;
        Status = ReservationStatus.Pending;
        NotificationId = command.NotificationId;
        CreatedAt = DateTime.UtcNow;
    }
    public Reservation(int id, ParentId parentId, BabysitterId babysitterId, ReservationDate startTime,
        ReservationDate endTime, string address, string frecuency, string childName,
        string childAge, string specialNeeds, string additionalInfo ,ReservationStatus status, NotificationId notificationId, DateTime createdAt)
    {
        Id = id;
        ParentId = parentId;
        BabysitterId = babysitterId;
        StartTime = startTime;
        EndTime = endTime;
        this.address = address;
        this.frecuency = frecuency;
        this.childName = childName;
        this.childAge = childAge;
        this.specialNeeds = specialNeeds;
        this.additionalInfo = additionalInfo;
        Status = status;
        NotificationId = notificationId;
        CreatedAt = createdAt;
    }

    public void Confirm() => Status.TransitionTo("CONFIRMED");
    public void Cancel() => Status.TransitionTo("CANCELED");
}