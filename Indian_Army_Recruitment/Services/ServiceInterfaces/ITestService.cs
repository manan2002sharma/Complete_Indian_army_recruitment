using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface ITestService
    {
        Task AddTestAsync(Test test);
        Task UpdateTestAsync(Test test);
        Task<Test> GetTestByIdAsync(Guid id);
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<IEnumerable<Test>> GetTestsByApplicationIdAsync(Guid applicationId);
        Task DeleteTestAsync(Guid id);
    }
}
