﻿using Indian_Army_Recruitment.Models;
namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface ICandidateProfileService
    {
        Task<CandidateProfile> GetProfileByUserIdAsync(Guid userId);
        Task AddCandidateProfileAsync(CandidateProfile profile);
        Task UpdateCandidateProfileAsync(CandidateProfile profile);
        Task DeleteCandidateProfileAsync(Guid userId);
    }
}
