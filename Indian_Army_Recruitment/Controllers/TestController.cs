using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        // Create a new Test
        [HttpPost]
        [Authorize(Roles = "Admin,Medical Officer")]
        public async Task<IActionResult> AddTest([FromBody] Test test)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _testService.AddTestAsync(test);
            return CreatedAtAction(nameof(GetTestById), new { id = test.TestId }, test);
        }

        // Retrieve a Test by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestById(Guid id)
        {
            var test = await _testService.GetTestByIdAsync(id);
            if (test == null)
                return NotFound("Test not found.");

            return Ok(test);
        }

        // Retrieve all Tests
        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {
            var tests = await _testService.GetAllTestsAsync();
            return Ok(tests);
        }

        // Retrieve Tests by ApplicationId
        [HttpGet("by-application/{applicationId}")]
        public async Task<IActionResult> GetTestsByApplicationId(Guid applicationId)
        {
            var tests = await _testService.GetTestsByApplicationIdAsync(applicationId);

            if (!tests.Any())
                return NotFound("No tests found for the given application ID.");

            return Ok(tests);
        }

        // Update a Test
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Medical Officer")]

        public async Task<IActionResult> UpdateTest(Guid id, [FromBody] Test updatedTest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != updatedTest.TestId)
                return BadRequest("Test ID mismatch.");

            try
            {
                await _testService.UpdateTestAsync(updatedTest);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete a Test
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Medical Officer")]
        public async Task<IActionResult> DeleteTest(Guid id)
        {
            try
            {
                await _testService.DeleteTestAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
