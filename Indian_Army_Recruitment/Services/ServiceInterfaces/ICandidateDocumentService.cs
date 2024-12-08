using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface ICandidateDocumentService
    {
        Task AddCandidateDocumentAsync(CandidateDocument candidateDocument);
        Task<CandidateDocument> GetCandidateDocumentByIdAsync(Guid id);
        Task<IEnumerable<CandidateDocument>> GetCandidateDocumentByApplicationIdAsync(Guid id);
        Task<List<CandidateDocument>> GetAllCandidateDocumentsAsync();
        Task UpdateCandidateDocumentAsync(CandidateDocument candidateDocument);
        Task DeleteCandidateDocumentAsync(Guid id);
    }
}
