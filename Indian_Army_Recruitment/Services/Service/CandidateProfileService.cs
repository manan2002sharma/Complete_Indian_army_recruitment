using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Services.ServiceInterfaces;

namespace Indian_Army_Recruitment.Services.Service
{
    public class CandidateProfileService:ICandidateProfileService
    {
        private readonly ICandidateProfileRepository _profileRepository;

        public CandidateProfileService(ICandidateProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<CandidateProfile> GetProfileByUserIdAsync(Guid userId)
        {
            return await _profileRepository.GetProfileByUserIdAsync(userId);
        }

        public async Task AddCandidateProfileAsync(CandidateProfile profile)
        {
            await _profileRepository.AddCandidateProfileAsync(profile);
        }

        public async Task UpdateCandidateProfileAsync(CandidateProfile profile)
        {
            await _profileRepository.UpdateCandidateProfileAsync(profile);
        }

        public async Task DeleteCandidateProfileAsync(Guid userId)
        {
            await _profileRepository.DeleteCandidateProfileAsync(userId);
        }
    }
}
