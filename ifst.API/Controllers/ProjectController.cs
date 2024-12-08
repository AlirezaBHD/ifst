using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProjectController: ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectController(IGeneralServices generalServices, IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost("AddProject/{institute.Id}")]
    public async Task<IActionResult> AddProject([FromRoute]GetObjectByIdDto institute,[FromForm] CreateProjectDto project)
    {
        await _projectService.AddProjectAsync(institute, project);
        return Ok(".پروژه با موفقیت اضافه شد");
    }
    
    [HttpGet("GetProject/{institute.Id}")]
    public async Task<IActionResult> GetProject([FromRoute]GetObjectByIdDto institute)
    {
        var project = await _projectService.GetProject(institute);
        return Ok(project);
    }
}