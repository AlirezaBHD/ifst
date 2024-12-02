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
    public string Name { get; set; }
    public string RequesterFullName { get; set; }

    public string RequesterEmail { get; set; }
    public string RequesterNationalId { get; set; }

    public IFormFile Image { get; set; }
    public string Description { get; set; }
}

public class ListedInstitutesDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImagesPath { get; set; }
    
}