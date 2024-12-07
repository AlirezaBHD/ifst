using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Application.DTOs;

public class InstituteDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImagesPath { get; set; }
    public string Description { get; set; }
    public IEnumerable<ProjectListDto> Projects { get; set; }
}

public class CreateInstituteDto
{
    [Required]
    public string Name { get; set; }
    [Required]

    public string RequesterFullName { get; set; }

    public string RequesterEmail { get; set; }
    [Required]

    public string RequesterNationalId { get; set; }
    [Required]


    public IFormFile Image { get; set; }
    [Required]

    public string Description { get; set; }
}

public class ListedInstitutesDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImagesPath { get; set; }
}

public class MainListedInstitutesDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImagesPath { get; set; }
    public bool Confirmed { get; set; }
    public string Description { get; set; }
}

public class PatchInstitutesDto 
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string RequesterFullName { get; set; }
    public string RequesterEmail { get; set; }
    [Required]
    public string RequesterNationalId { get; set; }
    [Required]
    public bool Confirmed { get; set; }
    [Required]
    public string ImagesPath { get; set; }
    [Required]
    public string Description { get; set; }
}

public class PatchInstitutesStatusDto
{
    public string Confirmed { get; set; } ="false";
}