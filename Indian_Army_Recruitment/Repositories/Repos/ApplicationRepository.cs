using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class ApplicationRepository:IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public ApplicationRepository(ApplicationDbContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // Add a new application
        public async Task AddApplicationAsync(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate Application Added";
                    string message = $@"
                        Your have Successfully Applied.

                        Vacancy Name: {application.VacancyName ?? "N/A"}
                        application Status: {application.ApplicationStatus ?? "N/A"}
                        application Id: {application.ApplicationId.ToString() ?? "No remarks provided."}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }
        }

        // Update an existing application
        public async Task UpdateApplicationAsync(Application application)
        {
            var existingApplication = await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationId == application.ApplicationId);

            if (existingApplication == null)
            {
                throw new InvalidOperationException("Application not found.");
            }

            // Update fields
            existingApplication.ApplicationStatus = application.ApplicationStatus;
            existingApplication.SubmissionDate = application.SubmissionDate;
            existingApplication.DocumentSubmitted = application.DocumentSubmitted;

            await _context.SaveChangesAsync();
        }

        // Retrieve application by ApplicationId
        public async Task<Application> GetApplicationByIdAsync(Guid applicationId)
        {
            return await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);
        }

        // Retrieve all applications
        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            return await _context.Applications
                .ToListAsync();
        }

        // Retrieve applications by UserId
        public async Task<List<Application>> GetApplicationsByUserIdAsync(Guid userId)
        {
            return await _context.Applications
                .Where(a => a.UserId == userId)// Include related Vacancy data
                .ToListAsync();
        }

        public async Task<List<Application>> GetApplicationsByVacancyIdAsync(Guid vacancyId)
        {
            return await _context.Applications
                .Where(a => a.VacancyId == vacancyId)// Include related Vacancy data
                .ToListAsync();
        }

        // Delete an application
        public async Task DeleteApplicationAsync(Guid applicationId)
        {
            var application = await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);

            if (application == null)
            {
                throw new InvalidOperationException("Application not found.");
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
        }
    }
}
