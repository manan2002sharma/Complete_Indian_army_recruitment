using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IPlatformAccessRepository
    {
        Task AddPlatformAccessAsync(PlatformAccess platformAccess);
        Task<IEnumerable<PlatformAccess>> GetAllPlatformAccessAsync();
    }
}
