using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    #region Injection

    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    #endregion


    #region Get Project

    [HttpGet("GetProject/{Id}")]
    public async Task<IActionResult> GetProject([FromRoute] GetObjectByIdDto projectDto)
    {
        var project = await _projectService.GetProject(projectDto);
        return Ok(project);
    }

    #endregion


    #region Add Project

    [HttpPost("AddProject/{institute.Id}")]
    public async Task<IActionResult> AddProject([FromRoute] GetObjectByIdDto institute,
        [FromForm] CreateProjectDto project)
    {
        var projectDto = await _projectService.AddProjectAsync(institute, project);
        return CreatedAtAction(nameof(GetProject), new { Id = projectDto.Id }, projectDto);
    }

    #endregion


    #region Delete Project

    [HttpDelete("DeleteProject/{Id}")]
    public async Task<IActionResult> DeleteProject([FromRoute] GetObjectByIdDto projectDto)
    {
        await _projectService.DeleteProject(projectDto);
        return Ok(".پروژه با موفقیت حذف شد");
    }

    #endregion

    
    #region Update Project

    [HttpPut("UpdateProject/{Id}")]
    public async Task<IActionResult> UpdateProject([FromRoute] GetObjectByIdDto projectId,
        [FromForm] InstituteUpdateProjectDto projectDto)
    {
        await _projectService.UpdateProject(projectId, projectDto);
        return Ok(".پروژه با موفقیت ویرایش شد");
    }

    #endregion

    #region GetProjects

    [HttpGet("GetAllProjects")]
    public async Task<IActionResult> GetAllProjectsName()
    {
        var projects =await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    #endregion
}