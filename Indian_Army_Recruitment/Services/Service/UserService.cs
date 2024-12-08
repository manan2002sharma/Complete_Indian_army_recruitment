using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.ReposInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public UserService(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> SignupAsync(User user, string password)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }
            var existingUser2 = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (existingUser2 != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            user.IsActive = true;
            await _userRepository.AddUserAsync(user, password);
            return "User registered successfully.";
        }

        public async Task<(string Token, User User)> LoginAsync(string username, string password)
        {
            var user = await _userRepository.LoginAsync(username, password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var token = _jwtService.GenerateToken(user.Username, user.Role,user.UserId);
            return (Token: token, User: user);
        }
    }
}
