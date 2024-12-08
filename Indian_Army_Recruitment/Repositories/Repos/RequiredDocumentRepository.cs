using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class RequiredDocumentRepository:IRequiredDocumentRepository
    {

        private readonly ApplicationDbContext _context;

        public RequiredDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a RequiredDocument
        public async Task AddRequiredDocumentAsync(RequiredDocument requiredDocument)
        {
            await _context.RequiredDocuments.AddAsync(requiredDocument);
            await _context.SaveChangesAsync();
        }

        //Get RequiredDocument by vacancy
        public async Task<List<RequiredDocument>> GetRequiredDocumentsByVacancyIdAsync(Guid vacancyId)
        {
            return await _context.RequiredDocuments
                .Where(rd => rd.VacancyId == vacancyId)
                .ToListAsync();
        }

        // Update a RequiredDocument
        public async Task UpdateRequiredDocumentAsync(RequiredDocument requiredDocument)
        {
            var existingDocument = await _context.RequiredDocuments
                .FirstOrDefaultAsync(rd => rd.RequiredDocumentId == requiredDocument.RequiredDocumentId);

            if (existingDocument == null)
                throw new InvalidOperationException("Required document not found.");

            existingDocument.DocumentType = requiredDocument.DocumentType;
            existingDocument.Description = requiredDocument.Description;
            existingDocument.VacancyId = requiredDocument.VacancyId;

            await _context.SaveChangesAsync();
        }

        // Retrieve a single RequiredDocument by ID
        public async Task<RequiredDocument> GetRequiredDocumentByIdAsync(Guid id)
        {
            return await _context.RequiredDocuments
                .FirstOrDefaultAsync(rd => rd.RequiredDocumentId == id);
        }

        // Retrieve all RequiredDocuments
        public async Task<IEnumerable<RequiredDocument>> GetAllRequiredDocumentsAsync()
        {
            return await _context.RequiredDocuments
                .ToListAsync();
        }

        // Delete a RequiredDocument
        public async Task DeleteRequiredDocumentAsync(Guid id)
        {
            var requiredDocument = await _context.RequiredDocuments
                .FirstOrDefaultAsync(rd => rd.RequiredDocumentId == id);

            if (requiredDocument == null)
                throw new InvalidOperationException("Required document not found.");

            _context.RequiredDocuments.Remove(requiredDocument);
            await _context.SaveChangesAsync();
        }
    }
}
