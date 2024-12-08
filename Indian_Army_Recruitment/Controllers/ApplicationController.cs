using Indian_Army_Recruitment.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> AddApplication([FromBody] Application application)
        {
            try
            {
                await _applicationService.AddApplicationAsync(application);
                //return Ok("Application added successfully.");
                return CreatedAtAction(nameof(GetApplicationById), new { id = application.ApplicationId }, application.ApplicationId);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> UpdateApplication([FromBody] Application application)
        {
            await _applicationService.UpdateApplicationAsync(application);
            return Ok("Application updated successfully.");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationById([FromRoute] Guid id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
                return NotFound("Application not found.");

            return Ok(application);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplicationsAsync();
            return Ok(applications);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetApplicationsByUserId([FromRoute] Guid userId)
        {
            var applications = await _applicationService.GetApplicationsByUserIdAsync(userId);
            return Ok(applications);
        }
        [HttpGet]
        [Route("vacancyId/{vacancyId}")]
        public async Task<IActionResult> GetApplicationsByVacancyId(Guid vacancyId)
        {
            var applications = await _applicationService.GetApplicationsByVacancyIdAsync(vacancyId);
            return Ok(applications);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
        {
            await _applicationService.DeleteApplicationAsync(id);
            return Ok("Application deleted successfully.");
        }
    }
}
