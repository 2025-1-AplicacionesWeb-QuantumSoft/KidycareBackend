using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Reservations.Domain.Repositories;

public interface IReservationRepository: IBaseRepository<Reservation>
{
    Task<Reservation?> GetReservationById(int reservationId);
    Task<Reservation> GetReservationByBabysitterIdAndParentId(BabysitterId babysitterId, ParentId parentId);
    
    Task<IEnumerable<Reservation>> GetReservationsByParentId(ParentId parentId);
    
    Task<IEnumerable<Reservation>> GetReservationsByBabysitterId(BabysitterId babysitterId);
    
    Task<Reservation?> UpdateReservation(Reservation reservation);
    
    Task DeleteReservation(int reservationId);
}