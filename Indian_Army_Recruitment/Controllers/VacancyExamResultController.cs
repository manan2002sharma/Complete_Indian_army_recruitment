using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyExamResultController : ControllerBase
    {
        private readonly IVacancyExamResultService _service;

        public VacancyExamResultController(IVacancyExamResultService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> AddVacancyExamResult([FromBody] VacancyExamResult examResult)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddVacancyExamResultAsync(examResult);
            return CreatedAtAction(nameof(GetVacancyExamResultById), new { id = examResult.ExamResultId }, examResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacancyExamResultById(Guid id)
        {
            var result = await _service.GetVacancyExamResultByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancyExamResults()
        {
            var results = await _service.GetAllVacancyExamResultsAsync();
            return Ok(results);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> DeleteVacancyExamResult(Guid id)
        {
            try
            {
                await _service.DeleteVacancyExamResultAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Vacancy exam result not found.");
            }
        }
        [HttpGet("by-application/{applicationId}")]
        public async Task<IActionResult> GetResultsByApplicationId(Guid applicationId)
        {
            var results = await _service.GetVacancyExamResultByApplicationIdAsync(applicationId);

            if (results == null || !results.Any())
                return NotFound("No exam results found for the given application ID.");

            return Ok(results);
        }
    }
}
