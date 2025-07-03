using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Interfaces.Resources;

namespace KidycareBackend.Reservations.Interfaces.Transform;

public class UpdateReservationByIdCommandFromResourceAssembler
{
    public static UpdateReservationByIdCommand ToCommandFromResource(
        UpdateReservationResource resource, int id)
    {
        return new UpdateReservationByIdCommand(
            id,
            resource.parentId,
            resource.babysitterId,
            resource.startTime,
            resource.endTime,
            resource.address,
            resource.frequency,
            resource.childName,
            resource.childAge,
            resource.specialNeeds,
            resource.additionalInfo,
            resource.status,
            resource.notificationId,
            resource.createdAt
        );
    }
}