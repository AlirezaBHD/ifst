using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class InstituteController : ControllerBase
{
    #region Injection

    private readonly IInstituteService _instituteService;
    private readonly FileService _fileService;
    private readonly IGeneralServices _generalServices;

    public InstituteController(IInstituteService instituteService,
        FileService fileService, IGeneralServices generalServices)
    {
        _instituteService = instituteService;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    #endregion

    #region Add Institute

    [HttpPost("AddInstitute")]
    public async Task<IActionResult> AddInstitute([FromForm] CreateInstituteDto instituteDto)
    {
        var newsletterObj = await _instituteService.AddInstitute(instituteDto);
        return Ok(newsletterObj);
    }

    #endregion

    #region Get Institute

    [HttpGet("GetInstitute{instituteDto.Id}")]
    public async Task<IActionResult> GetInstitute([FromRoute] GetObjectByIdDto instituteDto)
    {
        var newsletterObj = await _instituteService.GetInstitute(instituteDto.Id);
        return Ok(newsletterObj);
    }

    #endregion

    #region Deactivate Institute

    [HttpPatch("institute/{instituteDto.Id}/Deactivate")]
    public async Task<IActionResult> DeactiveInstitute([FromRoute] GetObjectByIdDto instituteDto)
    {
        var result = await _instituteService.Deactivate(instituteDto.Id);
        return Ok(result);
    }

    #endregion

    #region Activate Institute

    [HttpPatch("institute/{instituteDto.Id}/Activate")]
    public async Task<IActionResult> ActivateInstitute([FromRoute] GetObjectByIdDto instituteDto)
    {
        var result = await _instituteService.Activate(instituteDto.Id);
        return Ok(result);
    }

    #endregion

    #region Get All Institutes

    [HttpGet("GetAllInstitutes")]
    public async Task<IActionResult> GetAllInstitutes()
    {
        var newsletterObj = await _instituteService.GetAllInstitutes();
        return Ok(newsletterObj);
    }


    #endregion
    
    
}