using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UpdateProjectController : ControllerBase
{
    #region Injection

    private readonly IUpdateProjectService _updateProjectService;

    public UpdateProjectController(IUpdateProjectService IUpdateProjectService)
    {
        _updateProjectService = IUpdateProjectService;
    }

    #endregion
    
    #region Get Update Project

    [HttpGet("GetUpdateProject/{Id}")]
    public async Task<IActionResult> GetUpdateProject([FromRoute] GetObjectByIdDto updateProjectId)
    {
        var updateProject = await _updateProjectService.UpdateProjectDetail(updateProjectId.Id);
        return Ok(updateProject);
    }

    #endregion
    
    [HttpGet("GetUpdateProject/List")]
    public async Task<IActionResult> GetUpdateProjectList()
    {
        var updateProjects = await _updateProjectService.UpdateProjectList();
        return Ok(updateProjects);
    }

    [HttpPatch("UpdateProject/{Id}/Status")]
    public async Task<IActionResult> PatchUpdateProjectStatus([FromRoute] GetObjectByIdDto updateProjectId, [FromBody] PatchUpdateProjectDto updateProjectDto)
    {
        await _updateProjectService.UpdateStatus(updateProjectId.Id, updateProjectDto);
        return NoContent();
    }

    [HttpPost("UpdateProject/{Id}")]
    public async Task<IActionResult> PostUpdateProject([FromRoute] GetObjectByIdDto updateProjectId,[FromBody] AddUpdateProjectDto updateProjectDtoDto)
    {
        await _updateProjectService.AddUpdateProject(updateProjectId.Id, updateProjectDtoDto);
        return Ok(".بروزرسانی جدید برای پروژه با موفقیت ثبت گردید");
    }
    [HttpPut("UpdateProject/Update/{Id}")]
    public async Task<IActionResult> PutUpdateProject([FromRoute] GetObjectByIdDto updateProjectId,[FromBody] AddUpdateProjectDto updateProjectDtoDto)
    {
        await _updateProjectService.EditUpdateProject(updateProjectId.Id, updateProjectDtoDto);
        return Ok(".بروزرسانی پروژه با موفقیت ثبت گردید");
    }
    
    [HttpDelete("UpdateProject/{Id}/Delete")]
    public async Task<IActionResult> PutUpdateProject([FromRoute] GetObjectByIdDto updateProjectId)
    {
        await _updateProjectService.DeleteUpdateProject(updateProjectId.Id);
        return Ok(".بروزرسانی پروژه با موفقیت حذف گردید");
    }
}