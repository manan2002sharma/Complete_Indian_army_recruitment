using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class VacancyExamResultRepository:IVacancyExamResultRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyExamResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a VacancyExamResult
        public async Task AddVacancyExamResultAsync(VacancyExamResult examResult)
        {
            await _context.VacancyExamResults.AddAsync(examResult);
            await _context.SaveChangesAsync();
        }

        // Update a VacancyExamResult
        public async Task UpdateVacancyExamResultAsync(VacancyExamResult examResult)
        {
            var existingResult = await _context.VacancyExamResults
                .FirstOrDefaultAsync(er => er.ExamResultId == examResult.ExamResultId);

            if (existingResult == null)
                throw new InvalidOperationException("Exam result not found.");

            existingResult.ExamId = examResult.ExamId;
            existingResult.ApplicationId = examResult.ApplicationId;
            existingResult.Score = examResult.Score;
            existingResult.ResultStatus = examResult.ResultStatus;

            await _context.SaveChangesAsync();
        }

        // Retrieve a single VacancyExamResult by ID
        public async Task<VacancyExamResult> GetVacancyExamResultByIdAsync(Guid id)
        {
            return await _context.VacancyExamResults
                .FirstOrDefaultAsync(er => er.ExamResultId == id);
        }

        // Retrieve all VacancyExamResults
        public async Task<IEnumerable<VacancyExamResult>> GetAllVacancyExamResultsAsync()
        {
            return await _context.VacancyExamResults
                .ToListAsync();
        }

        // Delete a VacancyExamResult
        public async Task DeleteVacancyExamResultAsync(Guid id)
        {
            var examResult = await _context.VacancyExamResults
                .FirstOrDefaultAsync(er => er.ExamResultId == id);

            if (examResult == null)
                throw new InvalidOperationException("Exam result not found.");

            _context.VacancyExamResults.Remove(examResult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VacancyExamResult>> GetVacancyExamResultByApplicationIdAsync(Guid id)
        {
            return await _context.VacancyExamResults
                .Where(cd => cd.ApplicationId == id).ToListAsync(); ;
        }
    }
}
