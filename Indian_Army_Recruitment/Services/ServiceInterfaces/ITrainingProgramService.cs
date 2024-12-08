using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface ITrainingProgramService
    {
        Task AddTrainingProgramAsync(TrainingProgram trainingProgram);
        Task UpdateTrainingProgramAsync(TrainingProgram trainingProgram);
        Task<TrainingProgram> GetTrainingProgramByIdAsync(Guid trainingId);
        Task<IEnumerable<TrainingProgram>> GetAllTrainingProgramsAsync();
        Task<IEnumerable<TrainingProgram>> GetTrainingProgramsByApplicationIdAsync(Guid applicationId);
        Task DeleteTrainingProgramAsync(Guid trainingId);

    }
}
