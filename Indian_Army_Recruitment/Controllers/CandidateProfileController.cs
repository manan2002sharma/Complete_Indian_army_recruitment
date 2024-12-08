using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Indian_Army_Recruitment.Services.Service;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfileController : ControllerBase
    {

        private readonly ICandidateProfileService _profileService;

        public CandidateProfileController(ICandidateProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfileByUserId(Guid userId)
        {
            var profile = await _profileService.GetProfileByUserIdAsync(userId);
            if (profile == null)
                return NotFound("Profile not found.");
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateProfile([FromForm] CandidateProfile profile, IFormFile profilePicture)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (profilePicture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await profilePicture.CopyToAsync(memoryStream);
                    profile.ProfilePicture = memoryStream.ToArray(); // Save the file as a byte array
                }
            }

            await _profileService.AddCandidateProfileAsync(profile);
            return Ok("Profile added successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidateProfile([FromForm] CandidateProfile profile, IFormFile profilePicture)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (profilePicture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await profilePicture.CopyToAsync(memoryStream);
                    profile.ProfilePicture = memoryStream.ToArray(); // Save the file as a byte array
                }
            }
            await _profileService.UpdateCandidateProfileAsync(profile);
            return Ok("Profile updated successfully.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCandidateProfile(Guid userId)
        {
            await _profileService.DeleteCandidateProfileAsync(userId);
            return Ok("Profile deleted successfully.");
        }
    }
}
