using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IVacancyExamResultRepository
    {
        Task AddVacancyExamResultAsync(VacancyExamResult examResult);
        Task UpdateVacancyExamResultAsync(VacancyExamResult examResult);
        Task<VacancyExamResult> GetVacancyExamResultByIdAsync(Guid id);
        Task<IEnumerable<VacancyExamResult>> GetAllVacancyExamResultsAsync();
        Task<IEnumerable<VacancyExamResult>> GetVacancyExamResultByApplicationIdAsync(Guid id);
        Task DeleteVacancyExamResultAsync(Guid id);
    }
}
