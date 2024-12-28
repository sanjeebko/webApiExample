using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Dto;

public class AddRegionRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Code is required.")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Code must be exactly 3 characters long.")]
    public string Code { get; set; }
    public string? RegionImageUrl { get; set; }
}
