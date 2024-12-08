using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class TestRepository:ITestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public TestRepository(ApplicationDbContext context , IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // Add a Test
        public async Task AddTestAsync(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();

            var application = await _context.Applications
                                             .FirstOrDefaultAsync(app => app.ApplicationId == test.ApplicationId);

            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate test Added";
                    string message = $@"
                        Test has been Added!!!.

                        Test Type: {test.TestType ?? "N/A"}
                        Test date : {test.Date.ToString() ?? "N/A"}
                        Location: {test.Location ?? "No location provided."}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }
        }

        // Update a Test
        public async Task UpdateTestAsync(Test test)
        {
            var existingTest = await _context.Tests
                .FirstOrDefaultAsync(t => t.TestId == test.TestId);

            if (existingTest == null)
                throw new InvalidOperationException("Test not found.");

            existingTest.ApplicationId = test.ApplicationId;
            existingTest.TestType = test.TestType;
            existingTest.Date = test.Date;
            existingTest.Location = test.Location;
            existingTest.Status = test.Status;

            await _context.SaveChangesAsync();

            var application = await _context.Applications
                                             .FirstOrDefaultAsync(app => app.ApplicationId == test.ApplicationId);

            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate Test Updated";
                    string message = $@"
                        Test has been Updated!!!.

                        Test Type: {test.TestType ?? "N/A"}
                        Test date : {test.Date.ToString() ?? "N/A"}
                        Location: {test.Location ?? "No location provided."}
                        Remark: {test.Remarks ?? "No remark provided."}
                        status: {test.Status ?? "No status provided."}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }

        }

        // Retrieve a Test by ID
        public async Task<Test> GetTestByIdAsync(Guid id)
        {
            return await _context.Tests
                .FirstOrDefaultAsync(t => t.TestId == id);
        }

        // Retrieve all Tests
        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            return await _context.Tests
                .ToListAsync();
        }

        // Delete a Test
        public async Task DeleteTestAsync(Guid id)
        {
            var test = await _context.Tests
                .FirstOrDefaultAsync(t => t.TestId == id);

            if (test == null)
                throw new InvalidOperationException("Test not found.");

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Test>> GetTestsByApplicationIdAsync(Guid applicationId)
        {
            return await _context.Tests
                .Where(t => t.ApplicationId == applicationId)
                .ToListAsync();
        }
    }
}
