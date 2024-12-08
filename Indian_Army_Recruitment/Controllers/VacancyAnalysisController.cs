using Indian_Army_Recruitment.Services.Service;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyAnalysisController : ControllerBase
    {

        private readonly IVacancyAnalysisService _vacancyAnalysisService;

        public VacancyAnalysisController(IVacancyAnalysisService vacancyAnalysisService)
        {
            _vacancyAnalysisService = vacancyAnalysisService;
        }

        // GET api/vacancyanalysis/{vacancyId}
        [HttpGet("{vacancyId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetVacancyAnalysis(Guid vacancyId)
        {
            try
            {
                var analysis = _vacancyAnalysisService.GetVacancyAnalysis(vacancyId);
                return Ok(analysis);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
