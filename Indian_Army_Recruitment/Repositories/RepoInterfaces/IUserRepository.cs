using Indian_Army_Recruitment.Models;

namespace Indian_Army_Recruitment.Repositories.ReposInterfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user, string plainPassword);

        // Login a user with username and password
        Task<User> LoginAsync(string username, string password);

        // Get user by UserId
        Task<User> GetUserByIdAsync(Guid userId);

        // Get user by Username
        Task<User> GetUserByUsernameAsync(string username);

        //Get user by Email
        Task<User> GetUserByEmailAsync(string email);

        // Add Candidate Profile
        Task AddCandidateProfileAsync(CandidateProfile candidateProfile);

        // Update Candidate Profile
        Task UpdateCandidateProfileAsync(CandidateProfile candidateProfile);

        // Verify if the plain password matches the hashed password
        bool VerifyPassword(string plainPassword, string hashedPassword);
        string HashPassword(string plainPassword);
    }
}
