using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class VacancyExamRepository:IVacancyExamRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a new Vacancy Exam
        public async Task AddVacancyExamAsync(VacancyExam vacancyExam)
        {
            // Add the new exam to the VacancyExam DbSet
            _context.VacancyExams.Add(vacancyExam);
            await _context.SaveChangesAsync();
        }

        // Delete a Vacancy Exam by ExamId
        public async Task DeleteVacancyExamAsync(Guid examId)
        {
            var vacancyExam = await _context.VacancyExams
                .FirstOrDefaultAsync(v => v.ExamId == examId);

            if (vacancyExam == null)
            {
                throw new InvalidOperationException("Exam not found.");
            }

            // Remove the Vacancy Exam
            _context.VacancyExams.Remove(vacancyExam);
            await _context.SaveChangesAsync();
        }

        // Update an existing Vacancy Exam
        public async Task UpdateVacancyExamAsync(VacancyExam vacancyExam)
        {
            var existingExam = await _context.VacancyExams
                .FirstOrDefaultAsync(v => v.ExamId == vacancyExam.ExamId);

            if (existingExam == null)
            {
                throw new InvalidOperationException("Exam not found.");
            }

            // Update the exam details
            existingExam.ExamDate = vacancyExam.ExamDate;
            existingExam.TotalMarks = vacancyExam.TotalMarks;
            existingExam.PassingCriteria = vacancyExam.PassingCriteria;

            await _context.SaveChangesAsync();
        }

        // Retrieve a Vacancy Exam by ExamId
        public async Task<VacancyExam> GetVacancyExamByIdAsync(Guid examId)
        {
            return await _context.VacancyExams
                .FirstOrDefaultAsync(v => v.ExamId == examId);
        }

        // Retrieve all Exams for a specific Vacancy
        public async Task<List<VacancyExam>> GetVacancyExamsByVacancyIdAsync(Guid vacancyId)
        {
            return await _context.VacancyExams
                .Where(v => v.VacancyId == vacancyId)
                .ToListAsync();
        }
    }
}
