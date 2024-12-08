using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //RegisterUser
        public async Task AddUserAsync(User user, string plainPassword)
        {
            // Hash the plain password using bcrypt
            user.PasswordHash = HashPassword(plainPassword);

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        //Login User
        public async Task<User> LoginAsync(string username, string password)
        {
            // Find the user by username asynchronously
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            // If user is not found, return null 
            if (user == null)
            {
                return null;  
            }

            // Verify the provided password with the stored hash
            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;  // Return the user object if password is valid
            }
            else
            {
                return null;  
            }
        }
        // Method to get user data by UserId asynchronously
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            // Use asynchronous query to retrieve the user by UserId
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            return user;  // Returns the user object or null if not found
        }

        // Method to get user data by Username asynchronously
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            // Use asynchronous query to retrieve the user by Username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            return user;  // Returns the user object or null if not found
        }

        // Method to get user data by Email asynchronously
        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Use asynchronous query to retrieve the user by Email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            return user;  // Returns the user object or null if not found
        }

        //User Profile

        public async Task AddCandidateProfileAsync(CandidateProfile candidateProfile)
        {
            // Check if the profile already exists
            var existingProfile = await _context.CandidateProfiles
                .FirstOrDefaultAsync(c => c.UserId == candidateProfile.UserId);

            if (existingProfile != null)
            {
                throw new InvalidOperationException("Candidate profile already exists.");
            }

            // Add the new profile
            _context.CandidateProfiles.Add(candidateProfile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCandidateProfileAsync(CandidateProfile candidateProfile)
        {
            var existingProfile = await _context.CandidateProfiles
                .FirstOrDefaultAsync(c => c.UserId == candidateProfile.UserId);

            if (existingProfile == null)
            {
                throw new InvalidOperationException("Candidate profile not found.");
            }

            // Update the profile
            existingProfile.FullName = candidateProfile.FullName;
            existingProfile.DOB = candidateProfile.DOB;
            existingProfile.Qualifications = candidateProfile.Qualifications;
            existingProfile.Experience = candidateProfile.Experience;
            existingProfile.ProfilePicture = candidateProfile.ProfilePicture;
            existingProfile.MilitaryBackground = candidateProfile.MilitaryBackground;

            await _context.SaveChangesAsync();
        }

        //--------------------------------------------------------------------------------------------------

        //helper functions
        public string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }

    }
}
