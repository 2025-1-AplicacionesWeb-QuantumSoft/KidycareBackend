using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;
using KidycareBackend.Shared.Domain.Repositories;

namespace KidycareBackend.Profiles.Domain.Repositories;

public interface IParentRepository: IBaseRepository<Parent>
{
    Task<Parent?> GetParentById(int parentId);
    Task<Parent?> GetParentByUserId(int userId);
    Task<Parent?> UpdateParent(Parent parent);

}