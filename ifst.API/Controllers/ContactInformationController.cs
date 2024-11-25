using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactInformationController : ControllerBase
{
    private readonly IContactInformationService _contactInformationService;


    public ContactInformationController(IContactInformationService contactInformationService)
    {
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
        var contactInformation = await _contactInformationService.GetContactInformation();
        return Ok(contactInformation);
    }
}