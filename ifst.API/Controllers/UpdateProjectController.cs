using ifst.API.ifst.Application.DTOs;
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
    public async Task<IActionResult> GetProject([FromRoute] GetObjectByIdDto updateProjectId)
    {
        var updateProject = await _updateProjectService.UpdateProjectDetail(updateProjectId.Id);
        return Ok(updateProject);
    }

    #endregion
}