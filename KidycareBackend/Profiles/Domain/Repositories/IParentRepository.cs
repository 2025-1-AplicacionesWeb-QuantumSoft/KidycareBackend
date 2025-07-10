using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Repositories;

public interface IParentRepository: IBaseRepository<Parent>
{
    Task<Parent?> FindByUserIdAsync(int userId);
    Task<Parent?> Handle(GetParentByIdQuery query);
    Task<Parent?> Handle(GetParentByUserIdQuery query);
    Task<bool> ExistsByUserIdAsync(int userId);
}