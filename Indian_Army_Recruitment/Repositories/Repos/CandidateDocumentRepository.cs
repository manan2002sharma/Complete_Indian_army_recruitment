using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.Service;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class CandidateDocumentRepository:ICandidateDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public CandidateDocumentRepository(ApplicationDbContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task AddCandidateDocumentAsync(CandidateDocument candidateDocument)
        {
            _context.CandidateDocuments.Add(candidateDocument);
            await _context.SaveChangesAsync();
        }

        public async Task<CandidateDocument> GetCandidateDocumentByIdAsync(Guid id)
        {
            return await _context.CandidateDocuments
                .FirstOrDefaultAsync(cd => cd.CandidateDocumentId == id);
        }

        public async Task<IEnumerable<CandidateDocument>> GetCandidateDocumentByApplicationIdAsync(Guid id)
        {
            return await _context.CandidateDocuments
                .Where(cd => cd.ApplicationId == id).ToListAsync();
        }
        public async Task<List<CandidateDocument>> GetAllCandidateDocumentsAsync()
        {
            return await _context.CandidateDocuments
                .ToListAsync();
        }

        public async Task UpdateCandidateDocumentAsync(CandidateDocument candidateDocument)
        {
            _context.CandidateDocuments.Update(candidateDocument);
            await _context.SaveChangesAsync();
            // Fetch the ApplicationId from the updated candidate document
            var application = await _context.Applications
                                             .FirstOrDefaultAsync(app => app.ApplicationId == candidateDocument.ApplicationId);

            if (application != null)
            {
                // Retrieve the UserId from the application
                var user = await _context.Users
                                          .FirstOrDefaultAsync(u => u.UserId == application.UserId);

                if (user != null)
                {
                    // Compose the message with status, remarks, and document type
                    string subject = "Candidate Document Updated";
                    string message = $@"
                        Your candidate document has been successfully updated.

                        Document Type: {candidateDocument.DocumentType ?? "N/A"}
                        Verification Status: {candidateDocument.VerificationStatus ?? "N/A"}
                        Remarks: {candidateDocument.Remarks ?? "No remarks provided."}";

                    // Send email using the EmailService  // Inject IConfiguration as needed
                    await _emailService.SendEmailAsync(user.Email, subject, message);
                }
            }
        }

        public async Task DeleteCandidateDocumentAsync(Guid id)
        {
            var candidateDocument = await _context.CandidateDocuments.FindAsync(id);
            if (candidateDocument != null)
            {
                _context.CandidateDocuments.Remove(candidateDocument);
                await _context.SaveChangesAsync();
            }
        }
    }
}
