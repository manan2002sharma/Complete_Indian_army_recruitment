using Microsoft.AspNetCore.Http;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services;
using Microsoft.AspNetCore.Mvc;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateDocumentController : ControllerBase
    {

        private readonly ICandidateDocumentService _candidateDocumentService;

        public CandidateDocumentController(ICandidateDocumentService candidateDocumentService)
        {
            _candidateDocumentService = candidateDocumentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateDocument([FromBody] CandidateDocument candidateDocument)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _candidateDocumentService.AddCandidateDocumentAsync(candidateDocument);
            return Ok("Candidate document added successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateDocumentById(Guid id)
        {
            var candidateDocument = await _candidateDocumentService.GetCandidateDocumentByIdAsync(id);
            if (candidateDocument == null)
                return NotFound("Candidate document not found.");

            return Ok(candidateDocument);
        }
        [HttpGet("applicationId/{applicationId}")]
        public async Task<IActionResult> GetCandidateDocumentByApplicationId(Guid applicationId)
        {
            var candidateDocument = await _candidateDocumentService.GetCandidateDocumentByApplicationIdAsync(applicationId);
            if (candidateDocument == null)
                return NotFound("Candidate document not found.");
            return Ok(candidateDocument);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidateDocuments()
        {
            var candidateDocuments = await _candidateDocumentService.GetAllCandidateDocumentsAsync();
            return Ok(candidateDocuments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidateDocument(Guid id, [FromBody] CandidateDocument candidateDocument)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            candidateDocument.CandidateDocumentId = id;
            await _candidateDocumentService.UpdateCandidateDocumentAsync(candidateDocument);
            return Ok("Candidate document updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateDocument(Guid id)
        {
            await _candidateDocumentService.DeleteCandidateDocumentAsync(id);
            return Ok("Candidate document deleted successfully.");
        }
    }
}
