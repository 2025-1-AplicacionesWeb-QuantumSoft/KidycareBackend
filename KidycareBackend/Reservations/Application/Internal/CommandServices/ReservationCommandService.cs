using KidycareBackend.Profiles.Interfaces.ACL;
using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Domain.Repositories;
using KidycareBackend.Reservations.Domain.Services;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Reservations.Application.Internal.CommandServices;

public class ReservationCommandService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork, IProfilesContextFacade profilesContextFacade)
    : IReservationCommandService
{
    public async Task<Reservation?> handle(CreateReservationCommand command)
    {
        if (!await profilesContextFacade.ExistsParentWithIdAsync(command.ParentId.Value))
            throw new Exception("Parent not found.");

        if (!await profilesContextFacade.ExistsBabysitterWithIdAsync(command.BabysitterId.Value))
            throw new Exception("Babysitter not found.");
        
        var reservation =
            await reservationRepository.GetReservationByBabysitterIdAndParentId(command.BabysitterId, command.ParentId);
        if(reservation != null)
            throw new Exception("Reservation already exists");
        reservation = new Reservation(command);
        try
        {
            await reservationRepository.AddAsync(reservation);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return reservation;
    }

    public async Task<Reservation?> handle(UpdateReservationByIdCommand command)
    {
        var existReservation = await reservationRepository.GetReservationById(command.Id);
        if (existReservation == null)
            throw new Exception("Reservation not found");
        
        var reservation = new Reservation(
            command.Id, 
            command.parentId, 
            command.babysitterId, 
            command.startTime, 
            command.endTime, 
            command.address, 
            command.frequency, 
            command.childName, 
            command.childAge, 
            command.specialNeeds, 
            command.additionalInfo, 
            command.status, 
            command.notificationId, 
            command.createdAt
        );
        try
        {
            await reservationRepository.UpdateReservation(reservation);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return reservation;
    }

    public async Task<bool> handle(DeleteReservationByIdCommand command)
    {
        var reservation = await reservationRepository.GetReservationById(command.Id);
        if (reservation == null)
            throw new Exception("Reservation not found");
        try
        {
            await reservationRepository.DeleteReservation(reservation.Id);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
}