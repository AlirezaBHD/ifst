using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.FluentValidation.ValidationExtensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Infrastructure.FileManagement;
using JsonPatchSample.ifst.Application.FluentValidation.InstituteValidator;
using Microsoft.AspNetCore.JsonPatch;
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

    #region Patch Institute Status

    [HttpPatch("institute/{instituteDto.Id}/Status")]
    public async Task<IActionResult> UpdateInstituteStatus([FromRoute] GetObjectByIdDto instituteDto,
        [FromBody] PatchInstitutesStatusDto institutesStatusDto)
    {
        await _instituteService.InstituteStatus(instituteDto, institutesStatusDto);
        return NoContent();
    }
    
    

    #endregion

    #region Patch Institute

    [HttpPatch("{instituteDto.Id}")]
    public async Task<IActionResult> PatchInstitute([FromRoute]GetObjectByIdDto instituteDto, [FromBody]JsonPatchDocument<PatchInstitutesDto> patchDoc)
    {
        // if (patchDoc == null | patchDoc.Operations.Count == 0 | patchDoc.Operations.First().op == null)
        // {
        //     return BadRequest("سند تغییر الزامی است.");
        // }

        var validator = new PatchValidator<PatchInstitutesDto>();
        var validationResult = await validator.ValidateAsync(patchDoc);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("", validationResult.Errors);
        }
        await _instituteService.PatchInstitute(instituteDto.Id,patchDoc);
        return Ok(".ویرایش داده شد");
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

    #region Get All Confirmed Institutes

    [HttpGet("GetAllConfirmedInstitutes")]
    public async Task<IActionResult> GetAllConfirmedInstitutes()
    {
        var newsletterObj = await _instituteService.GetAllConfirmedInstitutes();
        return Ok(newsletterObj);
    }

    #endregion
    
}