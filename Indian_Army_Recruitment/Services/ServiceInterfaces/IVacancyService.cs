using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IVacancyService
    {
        Task AddVacancyAsync(Vacancy vacancy);
        Task UpdateVacancyAsync(Vacancy vacancy);
        Task<Vacancy> GetVacancyByIdAsync(Guid vacancyId);
        Task<List<Vacancy>> GetAllVacanciesAsync(Guid UserId);
        Task DeleteVacancyAsync(Guid vacancyId);
    }
}
