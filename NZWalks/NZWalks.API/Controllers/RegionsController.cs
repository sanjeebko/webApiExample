using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client.Region;
using NZWalks.API.AutoMapper;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repository;
using System.Diagnostics;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
     
    public IRegionRepository RegionRepository { get; }
    public IMapper Mapper { get; }

    public RegionsController( IRegionRepository regionRepository, IMapper mapper)
    {
        
        RegionRepository = regionRepository;
        Mapper = mapper;
    }

    /// <summary>
    /// Retrieves all regions.
    /// </summary>
    /// <returns>An IActionResult containing a list of all regions.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await RegionRepository.GetAllRegionsAsync();

        // Map domain models to DTOs
        var regionsDto = regions.Select(Mapper.Map<RegionDto>);

        return Ok(regionsDto);
    }

    /// <summary>
    /// Retrieves a region by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the region.</param>
    /// <returns>An IActionResult containing the region details or a NotFound result if the region does not exist.</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRegion([FromRoute] Guid id)
    {
        var region = await RegionRepository.GetRegionAsync(id);
        if (region is null)
            return NotFound();

        //map domain models to dto
        var regionDto =  Mapper.Map<RegionDto>(region);        

        return Ok(regionDto);
    }

    /// <summary>
    /// Creates a new region.
    /// </summary>
    /// <param name="addRegionRequestDto">The details of the region to create.</param>
    /// <returns>An IActionResult containing the created region details.</returns>
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
         
            var regionDomainMode = Mapper.Map<Region>(addRegionRequestDto);

            var region = await RegionRepository.CreateAsync(regionDomainMode);

            // map domain model back to regiondto
            var regionDto = Mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
         

    }

    /// <summary>
    /// Updates an existing region with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the region to update.</param>
    /// <param name="updateRegionRequestDto">The updated region details.</param>
    /// <returns>An IActionResult containing the updated region details or a NotFound result if the region does not exist.</returns>
    [HttpPut()]
    [Route("{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id,[FromBody] UpdateRegionRequestDto updateRegionRequestDto)
    {// map dto to domain model 
         
            var regionDomainMode = Mapper.Map<Region>(updateRegionRequestDto);

            var region = await RegionRepository.UpdateAsync(id, regionDomainMode);

            if (region is null)
                return NotFound();

            //convert region to dto
            var regionDto = Mapper.Map<RegionDto>(region);
            return Ok(regionDto);         
    }

    /// <summary>
    /// Deletes a region by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the region.</param>
    /// <returns>An IActionResult containing the deleted region details or a NotFound result if the region does not exist.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
    {        
        var region = await RegionRepository.DeleteAsync(id);
        if (region is null)
            return NotFound();

        //return delete region back.
        var regionDto =  Mapper.Map<RegionDto>(region);         
        return Ok(regionDto);
    }
}
