using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Interfaces.Resources;

namespace KidycareBackend.Reservations.Interfaces.Transform;

public class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource) =>
        new CreateReservationCommand( resource.BabysitterId, resource.ParentId, resource.StartTime,
            resource.EndTime, resource.address,resource.frequency,resource.childName,resource.childAge,resource.specialNeeds,
            resource.additionalInfo, resource.Status, resource.NotificationId, resource.createdAt);
}