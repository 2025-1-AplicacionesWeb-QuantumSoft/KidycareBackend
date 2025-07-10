using KidycareBackend.Profiles.Domain.Model.Aggregates;
using KidycareBackend.Profiles.Domain.Model.Queries;

namespace KidycareBackend.Profiles.Domain.Services;

public interface IParentQueryService
{
    Task<Parent?> Handle(GetParentByIdQuery query);
    
    Task<Parent?> Handle(GetParentByUserIdQuery query);

    Task<IEnumerable<Parent>> Handle(GetAllParentsQuery query);
}