using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class TrainingProgramRepository:ITrainingProgramRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public TrainingProgramRepository(ApplicationDbContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // Add a TrainingProgram
        public async Task AddTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            await _context.TrainingPrograms.AddAsync(trainingProgram);
            await _context.SaveChangesAsync();

            var application = await _context.Applications
                                             .FirstOrDefaultAsync(app => app.ApplicationId == trainingProgram.ApplicationId);

            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate Training Added";
                    string message = $@"
                        Your candidate Training has been successfully Added.

                        Training Title: {trainingProgram.Title ?? "N/A"}
                        Location : {trainingProgram.Location ?? "N/A"}
                        Start Date: {trainingProgram.StartDate.ToString() ?? "No Start date provided."}
                        End Date: {trainingProgram.EndDate.ToString() ?? "No End date provided."}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }

        }

        // Update a TrainingProgram
        public async Task UpdateTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            var existingProgram = await _context.TrainingPrograms
                .FirstOrDefaultAsync(tp => tp.TrainingId == trainingProgram.TrainingId);

            if (existingProgram == null)
                throw new InvalidOperationException("Training program not found.");

            existingProgram.ApplicationId = trainingProgram.ApplicationId;
            existingProgram.Title = trainingProgram.Title;
            existingProgram.Location = trainingProgram.Location;
            existingProgram.StartDate = trainingProgram.StartDate;
            existingProgram.EndDate = trainingProgram.EndDate;
            existingProgram.TrainerName = trainingProgram.TrainerName;
            existingProgram.Content = trainingProgram.Content;

            await _context.SaveChangesAsync();

            var application = await _context.Applications
                                 .FirstOrDefaultAsync(app => app.ApplicationId == trainingProgram.ApplicationId);

            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate Training Updated";
                    string message = $@"
                        Your candidate Training has been Updated.

                        Training Title: {trainingProgram.Title ?? "N/A"}
                        Location : {trainingProgram.Location ?? "N/A"}
                        Start Date: {trainingProgram.StartDate.ToString() ?? "No Start date provided."}
                        End Date: {trainingProgram.EndDate.ToString() ?? "No End date provided."}
                        Remark: {trainingProgram.Remark ?? "No Remark"}
                        Status: {trainingProgram.status ?? "No Status"}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }
        }

        // Retrieve a TrainingProgram by ID
        public async Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingId)
        {
            return await _context.TrainingPrograms
                .FirstOrDefaultAsync(tp => tp.TrainingId == trainingId);
        }

        // Retrieve all TrainingPrograms
        public async Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync()
        {
            return await _context.TrainingPrograms
                .ToListAsync();
        }

        // Delete a TrainingProgram
        public async Task DeleteTrainingProgramAsync(Guid trainingId)
        {
            var trainingProgram = await _context.TrainingPrograms
                .FirstOrDefaultAsync(tp => tp.TrainingId == trainingId);

            if (trainingProgram == null)
                throw new InvalidOperationException("Training program not found.");

            _context.TrainingPrograms.Remove(trainingProgram);
            await _context.SaveChangesAsync();
        }

        // Retrieve TrainingPrograms by ApplicationId
        public async Task<IEnumerable<TrainingProgram>> GetTrainingProgramsByApplicationIdAsync(Guid applicationId)
        {
            return await _context.TrainingPrograms
                .Where(tp => tp.ApplicationId == applicationId)
                .ToListAsync();
        }
    }
}
