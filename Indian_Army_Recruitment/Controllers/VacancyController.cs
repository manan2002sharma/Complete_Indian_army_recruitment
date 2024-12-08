using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        // Add a new vacancy
        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> AddVacancy([FromBody] Vacancy vacancy)
        {
            if (vacancy == null)
            {
                return BadRequest("Vacancy data is required.");
            }

            await _vacancyService.AddVacancyAsync(vacancy);
            return CreatedAtAction(nameof(GetVacancyById), new { vacancyId = vacancy.VacancyId }, vacancy.VacancyId);
        }

        // Update an existing vacancy
        [HttpPut("{vacancyId}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> UpdateVacancy(Guid vacancyId, [FromBody] Vacancy vacancy)
        {
            if (vacancyId != vacancy.VacancyId)
            {
                return BadRequest("Vacancy ID mismatch.");
            }

            var existingVacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);
            if (existingVacancy == null)
            {
                return NotFound("Vacancy not found.");
            }

            await _vacancyService.UpdateVacancyAsync(vacancy);
            return NoContent();
        }

        // Get a vacancy by its ID
        [HttpGet("{vacancyId}")]
        public async Task<IActionResult> GetVacancyById(Guid vacancyId)
        {
            var vacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);
            if (vacancy == null)
            {
                return NotFound("Vacancy not found.");
            }

            return Ok(vacancy);
        }

        // Get all vacancies
        [HttpGet("ForUser/{UserId}")]
        public async Task<IActionResult> GetAllVacancies(Guid UserId)
        {
            var vacancies = await _vacancyService.GetAllVacanciesAsync(UserId);
            return Ok(vacancies);
        }

        // Delete a vacancy by its ID
        [HttpDelete("{vacancyId}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> DeleteVacancy(Guid vacancyId)
        {
            var existingVacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);
            if (existingVacancy == null)
            {
                return NotFound("Vacancy not found.");
            }

            await _vacancyService.DeleteVacancyAsync(vacancyId);
            return NoContent();
        }
    }
}
