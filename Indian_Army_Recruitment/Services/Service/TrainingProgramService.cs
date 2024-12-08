using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class TrainingProgramService:ITrainingProgramService
    {
        private readonly ITrainingProgramRepository _repository;

        public TrainingProgramService(ITrainingProgramRepository repository)
        {
            _repository = repository;
        }

        public async Task AddTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            await _repository.AddTrainingProgramAsync(trainingProgram);
        }

        public async Task UpdateTrainingProgramAsync(TrainingProgram trainingProgram)
        {
            await _repository.UpdateTrainingProgramAsync(trainingProgram);
        }

        public async Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingId)
        {
            return await _repository.GetTrainingProgramByIdAsync(trainingId);
        }

        public async Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync()
        {
            return await _repository.GetAllTrainingProgramsAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> GetTrainingProgramsByApplicationIdAsync(Guid applicationId)
        {
            return await _repository.GetTrainingProgramsByApplicationIdAsync(applicationId);
        }

        public async Task DeleteTrainingProgramAsync(Guid trainingId)
        {
            await _repository.DeleteTrainingProgramAsync(trainingId);
        }
    }
}
