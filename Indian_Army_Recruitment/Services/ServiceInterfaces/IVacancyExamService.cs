using Indian_Army_Recruitment.Models;
namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IVacancyExamService
    {
        Task AddVacancyExamAsync(VacancyExam vacancyExam);
        Task DeleteVacancyExamAsync(Guid examId);
        Task UpdateVacancyExamAsync(VacancyExam vacancyExam);
        Task<VacancyExam> GetVacancyExamByIdAsync(Guid examId);
        Task<List<VacancyExam>> GetVacancyExamsByVacancyIdAsync(Guid vacancyId);

    }
}
