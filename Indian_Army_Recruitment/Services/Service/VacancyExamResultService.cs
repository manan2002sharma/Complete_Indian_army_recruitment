using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class VacancyExamResultService : IVacancyExamResultService
    {

        private readonly IVacancyExamResultRepository _repository;

        public VacancyExamResultService(IVacancyExamResultRepository repository)
        {
            _repository = repository;
        }

        public async Task AddVacancyExamResultAsync(VacancyExamResult examResult)
        {
            await _repository.AddVacancyExamResultAsync(examResult);
        }

        public async Task UpdateVacancyExamResultAsync(VacancyExamResult examResult)
        {
            await _repository.UpdateVacancyExamResultAsync(examResult);
        }

        public async Task<VacancyExamResult> GetVacancyExamResultByIdAsync(Guid id)
        {
            return await _repository.GetVacancyExamResultByIdAsync(id);
        }

        public async Task<IEnumerable<VacancyExamResult>> GetAllVacancyExamResultsAsync()
        {
            return await _repository.GetAllVacancyExamResultsAsync();
        }

        public async Task DeleteVacancyExamResultAsync(Guid id)
        {
            await _repository.DeleteVacancyExamResultAsync(id);
        }

        public async Task<IEnumerable<VacancyExamResult>> GetVacancyExamResultByApplicationIdAsync(Guid id)
        {
            return await _repository.GetVacancyExamResultByApplicationIdAsync(id);
        }
    }
}
