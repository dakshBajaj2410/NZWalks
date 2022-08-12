using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkdifficulty)
        {
            walkdifficulty.Id = Guid.NewGuid();
            await nZWalksDbContext.WalkDifficulty.AddAsync(walkdifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkdifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDomain = await nZWalksDbContext.WalkDifficulty.FindAsync(id);
            if (walkDomain == null)
            {
                return null;
            }
            nZWalksDbContext.Remove(walkDomain);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDomain;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nZWalksDbContext.WalkDifficulty.FindAsync(id);
     
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkdifficulty)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDifficulty.FindAsync(id);
            if(existingWalkDifficulty==null)
            {
                return null;
            }
            existingWalkDifficulty.Code = walkdifficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalkDifficulty; 
        }
    }
}
