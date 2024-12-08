using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class VacancyRepository:IVacancyRepository
    {
        private readonly ApplicationDbContext _context;

        public VacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a new Vacancy
        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            // Add the new vacancy to the database
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
        }

        // Update an existing Vacancy
        public async Task UpdateVacancyAsync(Vacancy vacancy)
        {
            var existingVacancy = await _context.Vacancies
                .FirstOrDefaultAsync(v => v.VacancyId == vacancy.VacancyId);

            if (existingVacancy == null)
            {
                throw new InvalidOperationException("Vacancy not found.");
            }

            // Update the fields
            existingVacancy.Title = vacancy.Title;
            existingVacancy.Role = vacancy.Role;
            existingVacancy.EligibilityCriteria = vacancy.EligibilityCriteria;
            existingVacancy.Location = vacancy.Location;
            existingVacancy.Salary = vacancy.Salary;
            existingVacancy.PostedBy = vacancy.PostedBy;
            existingVacancy.DatePosted = vacancy.DatePosted;
            existingVacancy.Status = vacancy.Status;

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        // Retrieve a Vacancy by its ID
        public async Task<Vacancy> GetVacancyByIdAsync(Guid vacancyId)
        {
            var vacancy = await _context.Vacancies
                .FirstOrDefaultAsync(v => v.VacancyId == vacancyId);

            return vacancy;  // Returns the vacancy or null if not found
        }
        // Retrieve all Vacancies
        public async Task<List<Vacancy>> GetAllVacanciesAsync(Guid userId)
        {
            // Get all the VacancyIds where the user has applied
            var appliedVacancyIds = await _context.Applications
                .Where(application => application.UserId == userId)
                .Select(application => application.VacancyId)
                .ToListAsync();

            // Get all vacancies excluding the ones the user has applied for
            var vacancies = await _context.Vacancies
                .Where(vacancy => !appliedVacancyIds.Contains(vacancy.VacancyId))
                .ToListAsync();

            return vacancies;
        }

        // Delete a Vacancy by its ID
        public async Task DeleteVacancyAsync(Guid vacancyId)
        {
            // Fetch applications related to the vacancy
            var applications = await _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .ToListAsync();

            // Delete related data for each application
            foreach (var application in applications)
            {
                // Delete VacancyExamResults linked to the application
                var examResults = await _context.VacancyExamResults
                    .Where(er => er.ApplicationId == application.ApplicationId)
                    .ToListAsync();
                _context.VacancyExamResults.RemoveRange(examResults);

                // Delete TrainingPrograms linked to the application
                var trainings = await _context.TrainingPrograms
                    .Where(tp => tp.ApplicationId == application.ApplicationId)
                    .ToListAsync();
                _context.TrainingPrograms.RemoveRange(trainings);

                // Delete CandidateDocuments linked to the application
                var candidateDocs = await _context.CandidateDocuments
                    .Where(cd => cd.ApplicationId == application.ApplicationId)
                    .ToListAsync();
                _context.CandidateDocuments.RemoveRange(candidateDocs);

                // Delete Tests linked to the application
                var tests = await _context.Tests
                    .Where(t => t.ApplicationId == application.ApplicationId)
                    .ToListAsync();
                _context.Tests.RemoveRange(tests);
            }

            // Delete RequiredDocuments linked to the vacancy
            var requiredDocs = await _context.RequiredDocuments
                .Where(rd => rd.VacancyId == vacancyId)
                .ToListAsync();
            _context.RequiredDocuments.RemoveRange(requiredDocs);

            // Delete VacancyExams linked to the vacancy
            var vacancyExams = await _context.VacancyExams
                .Where(ve => ve.VacancyId == vacancyId)
                .ToListAsync();
            _context.VacancyExams.RemoveRange(vacancyExams);

            // Delete Applications linked to the vacancy
            _context.Applications.RemoveRange(applications);

            // Finally, delete the Vacancy
            var vacancy = await _context.Vacancies
                .FirstOrDefaultAsync(v => v.VacancyId == vacancyId);
            if (vacancy == null)
            {
                throw new InvalidOperationException("Vacancy not found.");
            }
            _context.Vacancies.Remove(vacancy);

            // Save changes
            await _context.SaveChangesAsync();
        }
    }
}
