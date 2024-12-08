using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class RequiredDocumentService:IRequiredDocumentService
    {

        private readonly IRequiredDocumentRepository _requiredDocumentRepository;

        public RequiredDocumentService(IRequiredDocumentRepository requiredDocumentRepository)
        {
            _requiredDocumentRepository = requiredDocumentRepository;
        }

        public async Task<RequiredDocument> GetRequiredDocumentByIdAsync(Guid requiredDocumentId)
        {
            return await _requiredDocumentRepository.GetRequiredDocumentByIdAsync(requiredDocumentId);
        }

        public async Task<IEnumerable<RequiredDocument>> GetAllRequiredDocumentsAsync()
        {
            return await _requiredDocumentRepository.GetAllRequiredDocumentsAsync();
        }

        public async Task<List<RequiredDocument>> GetRequiredDocumentsByVacancyIdAsync(Guid vacancyId)
        {
            return await _requiredDocumentRepository.GetRequiredDocumentsByVacancyIdAsync(vacancyId);
        }

        public async Task AddRequiredDocumentAsync(RequiredDocument requiredDocument)
        {
            await _requiredDocumentRepository.AddRequiredDocumentAsync(requiredDocument);
        }

        public async Task UpdateRequiredDocumentAsync(RequiredDocument requiredDocument)
        {
            await _requiredDocumentRepository.UpdateRequiredDocumentAsync(requiredDocument);
        }

        public async Task DeleteRequiredDocumentAsync(Guid requiredDocumentId)
        {
            await _requiredDocumentRepository.DeleteRequiredDocumentAsync(requiredDocumentId);
        }
    }
}
