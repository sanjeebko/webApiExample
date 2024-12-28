using Microsoft.AspNetCore.Mvc;
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
        var existingWalk =await DbContext.Walks.Include(x=>x.Description).Include(x=>x.Region).FirstOrDefaultAsync(x => x.Id == id);
        if(existingWalk is null)
            return null;
        DbContext.Remove(existingWalk);
        await DbContext.SaveChangesAsync();
        return existingWalk;
    }

    public async Task<IEnumerable<Walk>> GetAllWalksAsync(string? filterOn = null,
                                                          string? filterQuery = null,
                                                          string? sortBy = null,
                                                          bool? isAscending = true,
                                                          int? pageNumber =1,
                                                          int? pageSize =1000)
    {
        var walks = DbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

        //filtering
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            switch (filterOn.ToLower())
            {
                case "name":
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                    break;
                case "region":
                    walks = walks.Where(x => x.Region.Name.Contains(filterQuery));
                    break;
                case "difficulty":
                    walks = walks.Where(x => x.Difficulty.Name.Contains(filterQuery));
                    break;
                default:
                    break;
            }
        }
        //sorting
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    walks = isAscending.Value ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                    break;
                case "region":
                    walks = isAscending.Value ? walks.OrderBy(x => x.Region.Name) : walks.OrderByDescending(x => x.Region.Name);
                    break;
                case "difficulty":
                    walks = isAscending.Value ? walks.OrderBy(x => x.Difficulty.Name) : walks.OrderByDescending(x => x.Difficulty.Name);
                    break;
                default:
                    break;
            }
        }

        //Pagination 
        if(pageNumber is not null && pageSize is not null)
            walks = walks.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

        return await walks.ToListAsync();
    }

    public Task<Walk?> GetWalkAsync(Guid id)  => DbContext.Walks.Include(a => a.Difficulty)
        .Include(a => a.Region)
        .FirstOrDefaultAsync(x => x.Id == id);
        

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        var existingWalk = await DbContext.Walks.Include("Difficulty")
        .Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk is null)
            return null;
        existingWalk.Name = walk.Name;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.LengthInKm =  walk.LengthInKm;                 
        existingWalk.RegionId = walk.RegionId;
        existingWalk.Description = walk.Description;
        existingWalk.DifficultyId = walk.DifficultyId;


        await DbContext.SaveChangesAsync();

        return existingWalk;

    }
}
