using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Repositories;

public interface IBabysitterRepository: IBaseRepository<Babysitter>
{
    Task<Babysitter?> GetBabysitterId(int babysitterId); 
    Task<Babysitter?> GetBabysitterByUserIdQuery(int userId);
    Task<Babysitter?> UpdateBabysitter(Babysitter babysitter);

}