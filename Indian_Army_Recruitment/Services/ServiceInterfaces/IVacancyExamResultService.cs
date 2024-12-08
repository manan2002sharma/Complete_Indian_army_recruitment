using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IVacancyExamResultService
    {
        Task AddVacancyExamResultAsync(VacancyExamResult examResult);
        Task UpdateVacancyExamResultAsync(VacancyExamResult examResult);
        Task<VacancyExamResult> GetVacancyExamResultByIdAsync(Guid id);
        Task<IEnumerable<VacancyExamResult>> GetAllVacancyExamResultsAsync();
        Task DeleteVacancyExamResultAsync(Guid id);
        Task<IEnumerable<VacancyExamResult>> GetVacancyExamResultByApplicationIdAsync(Guid id);

    }
}
