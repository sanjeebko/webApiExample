using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        public WalksController( IMapper mapper, IWalkRepository walkRepository)
        {
            Mapper = mapper;
            WalkRepository = walkRepository;
        }

        public IMapper Mapper { get; }
        public IWalkRepository WalkRepository { get; }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // dto to domain model 
            var walk = Mapper.Map<Walk>(addWalkRequestDto);
           var createdWalk = await WalkRepository.CreateAsync(walk);
            if(createdWalk is null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            // domain model to dto
            var walkDto = Mapper.Map<WalkDto>(createdWalk);
            return CreatedAtAction(nameof(GetWalk), new { id = walkDto.Id }, walkDto);
            
        }

        [HttpGet]        
        public async Task<IActionResult> GetAll()
        {
            var walks = await WalkRepository.GetAllWalksAsync();
            var walksDto = walks.Select(Mapper.Map<WalkDto>);
            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalk([FromRoute] Guid id)
        {
            var walk = await WalkRepository.GetWalkAsync(id);
            if (walk is null)
                return NotFound();
            var walkDto = Mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walk = Mapper.Map<Walk>(updateWalkRequestDto);
            var updatedWalk = await WalkRepository.UpdateAsync(id, walk);
            if (updatedWalk is null)
                return NotFound();
            var walkDto = Mapper.Map<WalkDto>(updatedWalk);
            return Ok(walkDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await WalkRepository.DeleteAsync(id);
            if (deletedWalk is null)
                return NotFound();
            var walkDto = Mapper.Map<WalkDto>(deletedWalk);
            return Ok(walkDto);
        }

    }
}
