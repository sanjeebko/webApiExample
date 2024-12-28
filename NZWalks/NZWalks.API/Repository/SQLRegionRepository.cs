﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NZWalksDbContext _dbContext;
    public SQLRegionRepository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        if (existingRegion is null)
            return null;

        _dbContext.Regions.Remove(existingRegion);
        await _dbContext.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<IEnumerable<Region>> GetAllRegionsAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }
    public async Task<Region?> GetRegionAsync(Guid id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
         var existingRegion =await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion is null)
            return  null;

        existingRegion.Name = region.Name;
        existingRegion.Code = region.Code;
        existingRegion.RegionImageUrl = region.RegionImageUrl;

        await _dbContext.SaveChangesAsync();
        return existingRegion;
    }
}


