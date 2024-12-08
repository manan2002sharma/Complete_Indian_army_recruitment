using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.Service;
using Indian_Army_Recruitment.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Indian_Army_Recruitment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IPlatformAccessService _platformservice;

        public UserController(UserService userService, IPlatformAccessService platformService)
        {
            _userService = userService;
            _platformservice= platformService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(User user)
        {
            try
            {
                var response = await _userService.SignupAsync(user, user.PasswordHash);

                return Ok(new { Message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCredentials loginRequest)
        {
            try
            {
                var (token, user) = await _userService.LoginAsync(loginRequest.username, loginRequest.password);

                PlatformAccess accessdata = new PlatformAccess { deviceinfo = loginRequest.deviceinfo , userName=loginRequest.username , accessDate= DateTime.Now};

                await _platformservice.AddPlatformAccessAsync(accessdata);

                return Ok(new
                {
                    Token = token,
                    User = new
                    {
                        user.UserId,
                        user.Username,
                        user.Email,
                        user.Role,
                        user.IsActive,
                        user.LastLogin
                    }
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("PlatformAccess")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPlatformAccess()
        {
            var platformAccessRecords = await _platformservice.GetAllPlatformAccessAsync();
            return Ok(platformAccessRecords);
        }
    }

}
