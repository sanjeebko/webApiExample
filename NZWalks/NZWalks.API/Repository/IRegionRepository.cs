using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository;

public interface IRegionRepository
{
    Task<IEnumerable<Region>> GetAllRegionsAsync();
    Task<Region?> GetRegionAsync(Guid id);

    Task<Region> CreateAsync(Region region);
    Task<Region?> UpdateAsync( Guid id, Region region);
    Task<Region?> DeleteAsync(Guid id);

}

