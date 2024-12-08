using Indian_Army_Recruitment.Models;
namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IDocumentVerificationRepository
    {
        Task AddDocumentVerificationAsync(DocumentVerification documentVerification);
        Task UpdateDocumentVerificationAsync(DocumentVerification documentVerification);
        Task<DocumentVerification> GetDocumentVerificationByIdAsync(Guid verificationId);
        Task<IEnumerable<DocumentVerification>> GetAllDocumentVerificationsAsync();
        Task DeleteDocumentVerificationAsync(Guid verificationId);
    }
}

