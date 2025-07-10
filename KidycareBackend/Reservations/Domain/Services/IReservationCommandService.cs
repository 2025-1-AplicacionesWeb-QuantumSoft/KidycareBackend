using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Commands;

namespace KidycareBackend.Reservations.Domain.Services;

public interface IReservationCommandService
{
    Task<Reservation> handle(CreateReservationCommand command);
    
    Task<bool> handle(DeleteReservationByIdCommand command);
    
    Task<Reservation> handle(UpdateReservationByIdCommand command);
}