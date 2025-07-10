using KidycareBackend.Reservations.Domain.Model.Aggregates;

namespace KidycareBackend.Reservations.Interfaces.ACL;

public interface IReservationContextFacade
{
    Task<Reservation?> GetReservationByIdAsync(int reservationId);
    Task<IEnumerable<Reservation?>> GetAllReservationsAsync();
}