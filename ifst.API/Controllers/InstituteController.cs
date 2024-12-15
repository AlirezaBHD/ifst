using FluentValidation;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
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

    public InstituteController(IInstituteService instituteService,
        FileService fileService)
    {
        _instituteService = instituteService;
        _fileService = fileService;
    }

    #endregion

    #region Add Institute

    [HttpPost("AddInstitute")]
    public async Task<IActionResult> AddInstitute([FromForm] CreateInstituteDto instituteDto)
    {
        var instituteObj = await _instituteService.AddInstitute(instituteDto);
        return Ok(instituteObj);
    }

    #endregion

    #region Get Institute

    [HttpGet("GetInstitute/{instituteDto.Id}")]
    public async Task<IActionResult> GetInstitute([FromRoute] GetObjectByIdDto instituteDto)
    {
        var instituteObj = await _instituteService.GetInstitute(instituteDto.Id);
        return Ok(instituteObj);
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

    [HttpGet("GetAllInstitutesPginated")]
    public async Task<IActionResult> GetAllInstitutesPginated([FromQuery] FilterAndSortPaginatedOptions options)
    {
        var institutesObj = await _instituteService.GetAllInstitutes(options.PageNumber , options.PageSize);
        return Ok(institutesObj);
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

    #region Get All Institutes and Projects
    
    [HttpGet("GetAllInstitutesAndProjects")]
    public async Task<IActionResult> GetAllInstitutesAndProjects()
    {
        var institutes = await _instituteService.GetAllInstitutesAndProjects();
        return Ok(institutes);
    }

    #endregion

    #region Update Institute

    

    
    [HttpPut("UpdateInstitute/{Id}")]
    public async Task<IActionResult> UpdateInstitute([FromRoute] GetObjectByIdDto instituteId, [FromForm] CreateInstituteDto instituteDto)
    {
        await _instituteService.UpdateInstitute(instituteId.Id , instituteDto);
        return Ok($".بنیاد {instituteDto.Name} با موفقیت ویرایش داده شد");
    }
    
    #endregion

    
}