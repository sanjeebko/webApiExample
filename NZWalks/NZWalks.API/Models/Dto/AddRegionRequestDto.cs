﻿namespace NZWalks.API.Models.Dto;

public class AddRegionRequestDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? RegionImageUrl { get; set; }
}
