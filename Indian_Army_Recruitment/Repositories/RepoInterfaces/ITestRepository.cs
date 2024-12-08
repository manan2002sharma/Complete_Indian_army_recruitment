using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface ITestRepository
    {
        Task AddTestAsync(Test test);
        Task UpdateTestAsync(Test test);
        Task<Test> GetTestByIdAsync(Guid id);
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task DeleteTestAsync(Guid id);
        Task<IEnumerable<Test>> GetTestsByApplicationIdAsync(Guid applicationId);

    }
}
