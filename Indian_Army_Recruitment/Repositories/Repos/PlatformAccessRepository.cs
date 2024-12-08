using Indian_Army_Recruitment.Data;
using Indian_Army_Recruitment.Models;
using Indian_Army_Recruitment.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Indian_Army_Recruitment.Repositories.Repos
{
    public class PlatformAccessRepository : IPlatformAccessRepository
    {
        private readonly ApplicationDbContext _context;

        public PlatformAccessRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a PlatformAccess record
        public async Task AddPlatformAccessAsync(PlatformAccess platformAccess)
        {
            await _context.PlatformAccesses.AddAsync(platformAccess);
            await _context.SaveChangesAsync();
        }

        // Get all PlatformAccess records
        public async Task<IEnumerable<PlatformAccess>> GetAllPlatformAccessAsync()
        {

            return await _context.PlatformAccesses.ToListAsync();
        }
    }
}
