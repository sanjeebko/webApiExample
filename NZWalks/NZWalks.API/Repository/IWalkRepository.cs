using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllWalksAsync();
    Task<Walk?> GetWalkAsync(Guid id);

    Task<Walk> CreateAsync(Walk walk);
    Task<Walk?> UpdateAsync(Guid id, Walk walk);
    Task<Walk?> DeleteAsync(Guid id);

}
