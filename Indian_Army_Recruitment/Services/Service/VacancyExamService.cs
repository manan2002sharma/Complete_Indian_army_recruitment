using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class VacancyExamService:IVacancyExamService
    {
        private readonly IVacancyExamRepository _vacancyExamRepository;

        public VacancyExamService(IVacancyExamRepository vacancyExamRepository)
        {
            _vacancyExamRepository = vacancyExamRepository;
        }
        public async Task AddVacancyExamAsync(VacancyExam vacancyExam)
        {
            await _vacancyExamRepository.AddVacancyExamAsync(vacancyExam);
        }

        public async Task DeleteVacancyExamAsync(Guid examId)
        {
            await _vacancyExamRepository.DeleteVacancyExamAsync(examId);
        }

        public async Task UpdateVacancyExamAsync(VacancyExam vacancyExam)
        {
            await _vacancyExamRepository.UpdateVacancyExamAsync(vacancyExam);
        }

        public async Task<VacancyExam> GetVacancyExamByIdAsync(Guid examId)
        {
            return await _vacancyExamRepository.GetVacancyExamByIdAsync(examId);
        }

        public async Task<List<VacancyExam>> GetVacancyExamsByVacancyIdAsync(Guid vacancyId)
        {
            return await _vacancyExamRepository.GetVacancyExamsByVacancyIdAsync(vacancyId);
        }
    }
}
