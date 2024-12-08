using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class CandidateDocumentService:ICandidateDocumentService
    {

        private readonly ICandidateDocumentRepository _candidateDocumentRepository;

        public CandidateDocumentService(ICandidateDocumentRepository candidateDocumentRepository)
        {
            _candidateDocumentRepository = candidateDocumentRepository;
        }

        public async Task AddCandidateDocumentAsync(CandidateDocument candidateDocument)
        {
            await _candidateDocumentRepository.AddCandidateDocumentAsync(candidateDocument);
        }

        public async Task<CandidateDocument> GetCandidateDocumentByIdAsync(Guid id)
        {
            return await _candidateDocumentRepository.GetCandidateDocumentByIdAsync(id);
        }

        public async Task<IEnumerable<CandidateDocument>> GetCandidateDocumentByApplicationIdAsync(Guid id)
        {
            return await _candidateDocumentRepository.GetCandidateDocumentByApplicationIdAsync(id);
        }
        public async Task<List<CandidateDocument>> GetAllCandidateDocumentsAsync()
        {
            return await _candidateDocumentRepository.GetAllCandidateDocumentsAsync();
        }

        public async Task UpdateCandidateDocumentAsync(CandidateDocument candidateDocument)
        {
            await _candidateDocumentRepository.UpdateCandidateDocumentAsync(candidateDocument);
        }

        public async Task DeleteCandidateDocumentAsync(Guid id)
        {
            await _candidateDocumentRepository.DeleteCandidateDocumentAsync(id);
        }
    }
}
