using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyExamController : ControllerBase
    {

        private readonly IVacancyExamService _vacancyExamService;

        public VacancyExamController(IVacancyExamService vacancyExamService)
        {
            _vacancyExamService = vacancyExamService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> AddVacancyExam([FromBody] VacancyExam vacancyExam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vacancyExamService.AddVacancyExamAsync(vacancyExam);
            return CreatedAtAction(nameof(GetVacancyExamById), new { id = vacancyExam.ExamId }, vacancyExam);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacancyExamById(Guid id)
        {
            var exam = await _vacancyExamService.GetVacancyExamByIdAsync(id);
            if (exam == null)
                return NotFound("Vacancy exam not found.");

            return Ok(exam);
        }

        [HttpGet("vacancy/{vacancyId}")]
        public async Task<IActionResult> GetVacancyExamsByVacancyId(Guid vacancyId)
        {
            var exams = await _vacancyExamService.GetVacancyExamsByVacancyIdAsync(vacancyId);
            return Ok(exams);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> UpdateVacancyExam(Guid id, [FromBody] VacancyExam vacancyExam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            vacancyExam.ExamId = id;
            await _vacancyExamService.UpdateVacancyExamAsync(vacancyExam);
            return Ok("Vacancy exam updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancyExam(Guid id)
        {
            await _vacancyExamService.DeleteVacancyExamAsync(id);
            return Ok("Vacancy exam deleted successfully.");
        }
    }
}
