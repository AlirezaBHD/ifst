
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;

namespace ifst.API.ifst.Application.DTOs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GatheringStartDate { get; set; }
    public string ImagePath { get; set; }
    public string CapitalRequired { get; set; }
    public string City { get; set; }
    public string Place { get; set; }
    public string GatheredSupport { get; set; }
    public string Summery { get; set; }
    public string Description { get; set; }
}

public class ProjectListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public string ImagePath { get; set; }
    public string CapitalRequired { get; set; }
    public string GatheredSupport { get; set; }
}

public class CreateProjectDto
{
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? GatheringStartDate { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? CapitalRequired { get; set; }
    public string? City { get; set; }
    public string? Place { get; set; }
    public string? GatheredSupport { get; set; }
    public string? Summery { get; set; }
    public string? Description { get; set; }
    // public string? InstituteId { get; set; }
}

public class ProjectDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GatheringStartDate { get; set; }
    public string ImagePath { get; set; }
    public string CapitalRequired { get; set; }
    public string City { get; set; }
    public string Place { get; set; }
    public string GatheredSupport { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    public string InstituteName { get; set; }
    public List<UpdateProjectDetailDto> Updates { get; set; }
}

public class InstituteUpdateProjectDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GatheringStartDate { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string CapitalRequired { get; set; }
    public string City { get; set; }
    public string Place { get; set; }
    public string GatheredSupport { get; set; }
    public string Summery { get; set; }
    public string Description { get; set; }

}

public class ProjectsName
{
    public int Id { get; set; }
    public string Name { get; set; }
}