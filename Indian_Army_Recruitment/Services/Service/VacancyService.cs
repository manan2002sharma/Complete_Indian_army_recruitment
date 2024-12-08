using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class VacancyService:IVacancyService
    {

        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            vacancy.DatePosted = DateTime.Now;
            await _vacancyRepository.AddVacancyAsync(vacancy);
        }

        public async Task UpdateVacancyAsync(Vacancy vacancy)
        {
            await _vacancyRepository.UpdateVacancyAsync(vacancy);
        }

        public async Task<Vacancy> GetVacancyByIdAsync(Guid vacancyId)
        {
            return await _vacancyRepository.GetVacancyByIdAsync(vacancyId);
        }

        public async Task<List<Vacancy>> GetAllVacanciesAsync(Guid UserId)
        {
            return await _vacancyRepository.GetAllVacanciesAsync(UserId);
        }

        public async Task DeleteVacancyAsync(Guid vacancyId)
        {
            await _vacancyRepository.DeleteVacancyAsync(vacancyId);
        }
    }
}
