using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IRequiredDocumentRepository
    {
        Task AddRequiredDocumentAsync(RequiredDocument requiredDocument);
        Task UpdateRequiredDocumentAsync(RequiredDocument requiredDocument);
        Task<RequiredDocument> GetRequiredDocumentByIdAsync(Guid id);
        Task<IEnumerable<RequiredDocument>> GetAllRequiredDocumentsAsync();
        Task DeleteRequiredDocumentAsync(Guid id);
        Task<List<RequiredDocument>> GetRequiredDocumentsByVacancyIdAsync(Guid vacancyId);
    }
}
