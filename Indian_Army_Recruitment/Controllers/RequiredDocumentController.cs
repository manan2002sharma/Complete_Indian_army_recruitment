using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequiredDocumentController : ControllerBase
    {
        private readonly IRequiredDocumentService _requiredDocumentService;

        public RequiredDocumentController(IRequiredDocumentService requiredDocumentService)
        {
            _requiredDocumentService = requiredDocumentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequiredDocumentById(Guid id)
        {
            var document = await _requiredDocumentService.GetRequiredDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequiredDocuments()
        {
            var documents = await _requiredDocumentService.GetAllRequiredDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("vacancy/{vacancyId}")]
        public async Task<IActionResult> GetRequiredDocumentsByVacancyId(Guid vacancyId)
        {
            var documents = await _requiredDocumentService.GetRequiredDocumentsByVacancyIdAsync(vacancyId);
            return Ok(documents);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> AddRequiredDocument([FromBody] RequiredDocument requiredDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _requiredDocumentService.AddRequiredDocumentAsync(requiredDocument);
            return CreatedAtAction(nameof(GetRequiredDocumentById), new { id = requiredDocument.RequiredDocumentId }, requiredDocument);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> UpdateRequiredDocument(Guid id, [FromBody] RequiredDocument requiredDocument)
        {
            if (!ModelState.IsValid || id != requiredDocument.RequiredDocumentId)
            {
                return BadRequest(ModelState);
            }

            var existingDocument = await _requiredDocumentService.GetRequiredDocumentByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _requiredDocumentService.UpdateRequiredDocumentAsync(requiredDocument);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> DeleteRequiredDocument(Guid id)
        {
            var existingDocument = await _requiredDocumentService.GetRequiredDocumentByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            await _requiredDocumentService.DeleteRequiredDocumentAsync(id);
            return NoContent();
        }
    }
}
