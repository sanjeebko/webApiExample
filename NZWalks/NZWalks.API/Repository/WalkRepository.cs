using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository;

public class WalkRepository : IWalkRepository
{
    public WalkRepository(NZWalksDbContext dbContext )
    {
        DbContext = dbContext;
    }

    public NZWalksDbContext DbContext { get; }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await DbContext.Walks.AddAsync(walk);
        await DbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var existingWalk =await DbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if(existingWalk is null)
            return null;
        DbContext.Remove(existingWalk);
        await DbContext.SaveChangesAsync();
        return existingWalk;
    }

    public async Task<IEnumerable<Walk>> GetAllWalksAsync() => await DbContext.Walks.Include("Difficulty")
        .Include("Region")
        .ToListAsync();

    public Task<Walk?> GetWalkAsync(Guid id)  => DbContext.Walks.Include(a => a.Difficulty)
        .Include(a => a.Region)
        .FirstOrDefaultAsync(x => x.Id == id);
        

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        var existingWalk = await DbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk is null)
            return null;
        existingWalk.Name = walk.Name;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.LengthInKm =  walk.LengthInKm;         
        existingWalk.Difficulty = walk.Difficulty;
        existingWalk.RegionId = walk.RegionId;
        existingWalk.Description = walk.Description;

        await DbContext.SaveChangesAsync();

        return existingWalk;

    }
}
