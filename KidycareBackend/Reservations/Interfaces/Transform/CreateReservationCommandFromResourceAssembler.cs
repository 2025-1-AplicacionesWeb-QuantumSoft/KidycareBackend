using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Interfaces.Resources;

namespace KidycareBackend.Reservations.Interfaces.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource) =>
        new CreateReservationCommand( resource.babysitterId, resource.parentId, resource.startTime,
            resource.endTime, resource.address,resource.frequency,resource.childName,resource.childAge,resource.specialNeeds,
            resource.additionalInfo, resource.status, resource.notificationId, resource.createdAt, resource.amount, resource.cardId);
}