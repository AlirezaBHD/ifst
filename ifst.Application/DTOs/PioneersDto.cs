using System.ComponentModel;

namespace ifst.API.ifst.Application.DTOs;

public class AddPioneersDto
{
    public string Name { get; set; }
    public string CityOfBirth { get; set; }
    public IFormFile File { get; set; }
    public string ProjectsDescription { get; set; }
}

public class GetPioneersDto
{
    public int Id { get; set; }
}

public class PioneersDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CityOfBirth { get; set; }
    public string ImagePath { get; set; }
    public string ProjectsDescription { get; set; }
}

public class GetAllPioneersDto
{
    [DefaultValue(1)] public int Page { get; set; }
    [DefaultValue(10)] public int PageSize { get; set; }
}

public class UpdatePioneerDto
{
    public string Name { get; set; }
    public string CityOfBirth { get; set; }
    public IFormFile? File { get; set; }
    public string ProjectsDescription { get; set; }
}