using Indian_Army_Recruitment.Models;
namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IApplicationService
    {
        Task AddApplicationAsync(Application application);
        Task UpdateApplicationAsync(Application application);
        Task<Application> GetApplicationByIdAsync(Guid applicationId);
        Task<List<Application>> GetAllApplicationsAsync();
        Task<List<Application>> GetApplicationsByUserIdAsync(Guid userId);
        Task DeleteApplicationAsync(Guid applicationId);
        Task<List<Application>> GetApplicationsByVacancyIdAsync(Guid vacancyId);
    }
}
