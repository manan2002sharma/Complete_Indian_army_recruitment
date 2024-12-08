using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class TestService:ITestService
    {

        private readonly ITestRepository _repository;

        public TestService(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task AddTestAsync(Test test)
        {
            await _repository.AddTestAsync(test);
        }

        public async Task UpdateTestAsync(Test test)
        {
            await _repository.UpdateTestAsync(test);
        }

        public async Task<Test> GetTestByIdAsync(Guid id)
        {
            return await _repository.GetTestByIdAsync(id);
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            return await _repository.GetAllTestsAsync();
        }

        public async Task<IEnumerable<Test>> GetTestsByApplicationIdAsync(Guid applicationId)
        {
            return await _repository.GetTestsByApplicationIdAsync(applicationId);
        }

        public async Task DeleteTestAsync(Guid id)
        {
            await _repository.DeleteTestAsync(id);
        }
    }
}
