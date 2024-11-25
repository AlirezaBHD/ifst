using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactInformationController : ControllerBase
{
    private readonly IContactInformationRepository _contactInformationRepository;
    private readonly GeneralServices _generalServices;
    private readonly IContactInformationService _contactInformationService;
    

    public ContactInformationController(IContactInformationService contactInformationService ,IContactInformationRepository contactInformationRepository,
        GeneralServices generalServices)
    {
        _contactInformationRepository = contactInformationRepository;
        _generalServices = generalServices;
        _contactInformationService = contactInformationService;
    }
    

    [HttpPut("UpdateContactInformation")]
    public async Task<IActionResult> UpdateContactInformation([FromBody] ContactInformationDto dto)
    {
        await _contactInformationService.UpdateContactInformation(dto);
        return Ok(dto);
    }

    [HttpGet("GetContactInformation")]
    public async Task<IActionResult> GetContactInformation()
    {
        var contactInformation = await _contactInformationRepository.GetByIdFirstOrDefaultAsync();

        return Ok(contactInformation);
    }
}