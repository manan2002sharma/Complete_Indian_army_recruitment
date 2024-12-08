using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IRequiredDocumentService
    {
        Task<RequiredDocument> GetRequiredDocumentByIdAsync(Guid requiredDocumentId);
        Task<IEnumerable<RequiredDocument>> GetAllRequiredDocumentsAsync();
        Task<List<RequiredDocument>> GetRequiredDocumentsByVacancyIdAsync(Guid vacancyId);
        Task AddRequiredDocumentAsync(RequiredDocument requiredDocument);
        Task UpdateRequiredDocumentAsync(RequiredDocument requiredDocument);
        Task DeleteRequiredDocumentAsync(Guid requiredDocumentId);

    }
}
