using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class DocumentVerificationRepository:IDocumentVerificationRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentVerificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a DocumentVerification record
        public async Task AddDocumentVerificationAsync(DocumentVerification documentVerification)
        {
            await _context.DocumentVerifications.AddAsync(documentVerification);
            await _context.SaveChangesAsync();
        }

        // Update a DocumentVerification record
        public async Task UpdateDocumentVerificationAsync(DocumentVerification documentVerification)
        {
            var existingRecord = await _context.DocumentVerifications
                .FirstOrDefaultAsync(dv => dv.VerificationId == documentVerification.VerificationId);

            if (existingRecord == null)
                throw new InvalidOperationException("Document verification record not found.");

            existingRecord.CandidateDocumentID = documentVerification.CandidateDocumentID;
            existingRecord.DocumentType = documentVerification.DocumentType;
            existingRecord.VerificationStatus = documentVerification.VerificationStatus;
            existingRecord.Remarks = documentVerification.Remarks;

            await _context.SaveChangesAsync();
        }

        // Retrieve a DocumentVerification record by ID
        public async Task<DocumentVerification> GetDocumentVerificationByIdAsync(Guid verificationId)
        {
            return await _context.DocumentVerifications
                .FirstOrDefaultAsync(dv => dv.VerificationId == verificationId);
        }

        // Retrieve all DocumentVerification records
        public async Task<IEnumerable<DocumentVerification>> GetAllDocumentVerificationsAsync()
        {
            return await _context.DocumentVerifications
                .ToListAsync();
        }

        // Delete a DocumentVerification record
        public async Task DeleteDocumentVerificationAsync(Guid verificationId)
        {
            var existingRecord = await _context.DocumentVerifications
                .FirstOrDefaultAsync(dv => dv.VerificationId == verificationId);

            if (existingRecord == null)
                throw new InvalidOperationException("Document verification record not found.");

            _context.DocumentVerifications.Remove(existingRecord);
            await _context.SaveChangesAsync();
        }
    }
}
