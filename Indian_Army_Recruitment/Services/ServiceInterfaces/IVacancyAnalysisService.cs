using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IVacancyAnalysisService
    {
        VacancyAnalysis GetVacancyAnalysis(Guid vacancyId);
    }
}
