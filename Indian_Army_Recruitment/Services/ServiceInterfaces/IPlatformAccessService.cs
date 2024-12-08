using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IPlatformAccessService
    {
        Task AddPlatformAccessAsync(PlatformAccess platformAccess);
        Task<IEnumerable<PlatformAccess>> GetAllPlatformAccessAsync();
    }
}
