namespace KidycareBackend.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<bool> ExistsParentWithIdAsync(int parentId);
    Task<bool> ExistsBabysitterWithIdAsync(int babysitterId);
    //Task<string> GetFullNameByProfileIdAsync(int profileId);
}