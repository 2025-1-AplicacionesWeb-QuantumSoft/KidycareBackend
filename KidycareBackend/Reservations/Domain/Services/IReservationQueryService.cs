using KidycareBackend.Reservations.Domain.Model.Aggregates;
using KidycareBackend.Reservations.Domain.Model.Commands;
using KidycareBackend.Reservations.Domain.Model.Queries;
using KidycareBackend.Reservations.Domain.Model.ValueObjects;

namespace KidycareBackend.Reservations.Domain.Services;

public interface IReservationQueryService
{
    Task<IEnumerable<Reservation>> handle(GetAllReservationByParentIdQuery query);

    Task<IEnumerable<Reservation>> handle(GetAllReservationByBabysitterIdQuery query);
    
    Task<IEnumerable<Reservation>> handle(GetAllReservationsQuery query);

    Task<Reservation> handle(GetReservationByIdQuery command);
}