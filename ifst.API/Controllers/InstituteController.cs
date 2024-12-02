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
    [HttpPost("AddInstitute")]
    public async Task<IActionResult> AddInstitute([FromForm] CreateInstituteDto instituteDto)
    {
        var newsletterObj = await _instituteService.AddInstitute(instituteDto);
        return Ok(newsletterObj);
    }
}