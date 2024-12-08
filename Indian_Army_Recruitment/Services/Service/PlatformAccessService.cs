using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class PlatformAccessService : IPlatformAccessService
    {
        private readonly IPlatformAccessRepository _repository;

        public PlatformAccessService(IPlatformAccessRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPlatformAccessAsync(PlatformAccess platformAccess)
        {
            await _repository.AddPlatformAccessAsync(platformAccess);
        }

        public async Task<IEnumerable<PlatformAccess>> GetAllPlatformAccessAsync()
        {
            return await _repository.GetAllPlatformAccessAsync();
        }
    }
}
