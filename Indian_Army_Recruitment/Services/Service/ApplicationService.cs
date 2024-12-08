using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.Repos;
namespace Indian_Army_Recruitment.Services.Service
{
    public class ApplicationService:IApplicationService
    {

        private readonly IApplicationRepository _applicationRepository;
        private readonly IRequiredDocumentRepository _requiredDocumentRepository;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IRequiredDocumentRepository requiredDocumentRepository)
        {
            _applicationRepository = applicationRepository;
            _requiredDocumentRepository = requiredDocumentRepository;
        }

        public async Task AddApplicationAsync(Application application)
        {
            application.DocumentSubmitted = true;
            application.SubmissionDate = DateTime.Now;
            application.ApplicationStatus = "Open";
            await _applicationRepository.AddApplicationAsync(application);
        }


        public async Task UpdateApplicationAsync(Application application)
        {
            await _applicationRepository.UpdateApplicationAsync(application);
        }

        public async Task<Application> GetApplicationByIdAsync(Guid applicationId)
        {
            return await _applicationRepository.GetApplicationByIdAsync(applicationId);
        }

        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            return await _applicationRepository.GetAllApplicationsAsync();
        }

        public async Task<List<Application>> GetApplicationsByUserIdAsync(Guid userId)
        {
            return await _applicationRepository.GetApplicationsByUserIdAsync(userId);
        }
        public async Task<List<Application>> GetApplicationsByVacancyIdAsync(Guid vacancyId)
        {
            return await _applicationRepository.GetApplicationsByVacancyIdAsync(vacancyId);
        }

        public async Task DeleteApplicationAsync(Guid applicationId)
        {
            await _applicationRepository.DeleteApplicationAsync(applicationId);
        }
    }

}
