using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class VacancyAnalysisService:IVacancyAnalysisService
    {
        private readonly ApplicationDbContext _context;

        public VacancyAnalysisService(ApplicationDbContext context)
        {
            _context = context;
        }

        public VacancyAnalysis GetVacancyAnalysis(Guid vacancyId)
        {
            var vacancy = _context.Vacancies
                .Where(v => v.VacancyId == vacancyId)
                .Select(v => new
                {
                    v.Title,
                    v.DatePosted,
                    v.PostedBy
                }).FirstOrDefault();

            if (vacancy == null) throw new Exception("Vacancy not found.");

            var postedByUser = _context.Users
                .Where(u => u.UserId == vacancy.PostedBy)
                .Select(u => u.Username)
                .FirstOrDefault();

            var examResults = _context.VacancyExams
                .Where(ve => ve.VacancyId == vacancyId)
                .Select(ve => new
                {
                    ve.ExamId,
                    ve.ExamName,
                    ve.ExamDate
                })
                .ToList();

            var resultAnalysis = examResults.Select(exam => new ExamResultAnalysis
            {
                ExamName = exam.ExamName,
                ExamDate = exam.ExamDate,
                TotalParticipants = _context.VacancyExamResults
                    .Where(er => er.ExamId == exam.ExamId)
                    .Select(er => er.ApplicationId)
                    .Distinct()
                    .Count(),
                PassedCandidates = _context.VacancyExamResults
                    .Where(er => er.ExamId == exam.ExamId && er.ResultStatus == "Pass")
                    .Select(er => er.ApplicationId)
                    .Distinct()
                    .Count()
            }).ToArray();

            var statusResult = _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .GroupBy(a => a.ApplicationStatus)
                .Select(g => new StatusResult
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToArray();

            var stateResult = _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .Join(_context.CandidateProfiles,
                    app => app.UserId,
                    profile => profile.UserId,
                    (app, profile) => profile.State)
                .GroupBy(state => state)
                .Select(g => new StateResult
                {
                    StateName = g.Key,
                    TotalCandidates = g.Count()
                })
                .ToArray();

            var successRate = 0.0; // Default value in case of zero participants
            var totalParticipants = resultAnalysis.Sum(r => r.TotalParticipants);
            var passedCandidates = resultAnalysis.Sum(r => r.PassedCandidates);

            if (totalParticipants > 0)
            {
                successRate = (double)passedCandidates / totalParticipants * 100;
            }
            var analysis = new VacancyAnalysis
            {
                VacancyId = vacancyId,
                VacancyName = vacancy.Title,
                DateGenerated = vacancy.DatePosted,
                PostedBy = postedByUser,
                ResultAnalysis = resultAnalysis,
                Status = statusResult,
                States = stateResult,
                SuccessRate = double.IsNaN(successRate) || double.IsInfinity(successRate) ? 0.0 : successRate

        };

            return analysis;
        }
    }

}
