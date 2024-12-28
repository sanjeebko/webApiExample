using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Dto;

public class AddWalkRequestDto
{
    [Required(ErrorMessage = "Please provide a name.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "The name must be between 4 and 100 characters long.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please provide a description.")]
    [StringLength(500, MinimumLength = 4, ErrorMessage = "The description must be between 4 and 500 characters long.")]
    public string Description { get; set; }
    [Range(0.1,200, ErrorMessage = "The length in kilometers must be between 0.1 and 200.")]
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }
}
