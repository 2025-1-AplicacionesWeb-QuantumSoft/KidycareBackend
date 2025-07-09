using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Repositories;

public interface IBabysitterRepository: IBaseRepository<Babysitter>
{
    Task<Babysitter?> FindByUserIdAsync(int userId);
    Task<Babysitter?> Handle(GetBabysitterByIdQuery query);
    Task<Babysitter?> Handle(GetBabysitterByUserIdQuery query);
    Task<bool> ExistsByUserIdAsync(int userId);
}