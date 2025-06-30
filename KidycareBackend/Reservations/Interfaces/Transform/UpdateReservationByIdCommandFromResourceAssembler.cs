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
            resource.ParentId,
            resource.BabysitterId,
            resource.StartTime,
            resource.EndTime,
            resource.address,
            resource.frecuency,
            resource.ChildName,
            resource.ChildAge,
            resource.SpecialNeeds,
            resource.AdditionalInfo,
            resource.Status,
            resource.NotificationId,
            resource.CreatedAt
        );
    }
}