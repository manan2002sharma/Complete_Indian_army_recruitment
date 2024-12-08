using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface ITrainingProgramRepository
    {
        Task AddTrainingProgramAsync(TrainingProgram trainingProgram);
        Task UpdateTrainingProgramAsync(TrainingProgram trainingProgram);
        Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingId);
        Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync();
        Task DeleteTrainingProgramAsync(Guid trainingId);
        Task<IEnumerable<TrainingProgram>> GetTrainingProgramsByApplicationIdAsync(Guid applicationId); 
    }
}
