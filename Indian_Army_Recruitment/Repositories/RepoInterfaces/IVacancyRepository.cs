using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.RepoInterfaces
{
    public interface IVacancyRepository
    {
        // Method to add a new Vacancy
        Task AddVacancyAsync(Vacancy vacancy);

        // Method to update an existing Vacancy
        Task UpdateVacancyAsync(Vacancy vacancy);

        // Method to get a Vacancy by its ID
        Task<Vacancy> GetVacancyByIdAsync(Guid vacancyId);

        // Method to get all Vacancies
        Task<List<Vacancy>> GetAllVacanciesAsync(Guid UserId);

        // Method to delete a Vacancy by its ID
        Task DeleteVacancyAsync(Guid vacancyId);
    }
}
