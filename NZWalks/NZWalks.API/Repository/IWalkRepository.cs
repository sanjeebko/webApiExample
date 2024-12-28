using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using System.Globalization;

namespace NZWalks.API.Repository;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllWalksAsync(string? filterOn = null,
                                             string? filterQuery = null,
                                             string? sortBy = null,
                                             bool? isAscending = true,
                                             int? pageNumber =1,
                                             int? pageSize=1000);
    Task<Walk?> GetWalkAsync(Guid id);

    Task<Walk> CreateAsync(Walk walk);
    Task<Walk?> UpdateAsync(Guid id, Walk walk);
    Task<Walk?> DeleteAsync(Guid id);

}
