using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IVacancyExamRepository
    {
        // Method to add a new Vacancy Exam
        Task AddVacancyExamAsync(VacancyExam vacancyExam);

        // Method to delete a Vacancy Exam by ExamId
        Task DeleteVacancyExamAsync(Guid examId);

        // Method to update an existing Vacancy Exam
        Task UpdateVacancyExamAsync(VacancyExam vacancyExam);

        // Method to retrieve a Vacancy Exam by ExamId
        Task<VacancyExam> GetVacancyExamByIdAsync(Guid examId);

        // Method to retrieve all Exams for a specific Vacancy
        Task<List<VacancyExam>> GetVacancyExamsByVacancyIdAsync(Guid vacancyId);
    }
}
