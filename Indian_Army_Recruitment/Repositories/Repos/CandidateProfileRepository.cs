using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class CandidateProfileRepository: ICandidateProfileRepository
    {

        private readonly ApplicationDbContext _context;

        public CandidateProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CandidateProfile> GetProfileByUserIdAsync(Guid userId)
        {
            return await _context.CandidateProfiles
                .FirstOrDefaultAsync(cp => cp.UserId == userId);
        }

        public async Task AddCandidateProfileAsync(CandidateProfile profile)
        {
            _context.CandidateProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidateProfileAsync(CandidateProfile profile)
        {
            var existingProfile = await _context.CandidateProfiles.FirstOrDefaultAsync(cp => cp.UserId == profile.UserId);
            if (existingProfile == null)
                throw new InvalidOperationException("Profile not found.");

            existingProfile.FullName = profile.FullName;
            existingProfile.DOB = profile.DOB;
            existingProfile.Qualifications = profile.Qualifications;
            existingProfile.Experience = profile.Experience;
            existingProfile.ProfilePicture = profile.ProfilePicture;
            existingProfile.MilitaryBackground = profile.MilitaryBackground;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCandidateProfileAsync(Guid userId)
        {
            var profile = await _context.CandidateProfiles.FirstOrDefaultAsync(cp => cp.UserId == userId);
            if (profile == null)
                throw new InvalidOperationException("Profile not found.");

            _context.CandidateProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}
