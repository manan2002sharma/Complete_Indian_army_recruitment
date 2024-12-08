using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingProgramController : ControllerBase
    {

        private readonly ITrainingProgramService _service;

        public TrainingProgramController(ITrainingProgramService service)
        {
            _service = service;
        }

        // Add a new TrainingProgram
        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> AddTrainingProgram([FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddTrainingProgramAsync(trainingProgram);
            return CreatedAtAction(nameof(GetTrainingProgramById), new { id = trainingProgram.TrainingId }, trainingProgram);
        }

        // Retrieve a TrainingProgram by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingProgramById(Guid id)
        {
            var trainingProgram = await _service.GetTrainingProgramByIdAsync(id);
            if (trainingProgram == null)
                return NotFound("Training program not found.");

            return Ok(trainingProgram);
        }

        // Retrieve all TrainingPrograms
        [HttpGet]
        public async Task<IActionResult> GetAllTrainingPrograms()
        {
            var trainingPrograms = await _service.GetAllTrainingProgramsAsync();
            return Ok(trainingPrograms);
        }

        // Retrieve TrainingPrograms by ApplicationId
        [HttpGet("by-application/{applicationId}")]
        public async Task<IActionResult> GetTrainingProgramsByApplicationId(Guid applicationId)
        {
            var trainingPrograms = await _service.GetTrainingProgramsByApplicationIdAsync(applicationId);

            if (!trainingPrograms.Any())
                return NotFound("No training programs found for the given application ID.");

            return Ok(trainingPrograms);
        }

        // Update a TrainingProgram
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> UpdateTrainingProgram(Guid id, [FromBody] TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != trainingProgram.TrainingId)
                return BadRequest("Training ID mismatch.");

            try
            {
                await _service.UpdateTrainingProgramAsync(trainingProgram);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete a TrainingProgram
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> DeleteTrainingProgram(Guid id)
        {
            try
            {
                await _service.DeleteTrainingProgramAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
