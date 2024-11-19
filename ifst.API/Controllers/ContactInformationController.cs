using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactInformationController : ControllerBase
{
    private readonly IContactInformationRepository _repository;
    private readonly GeneralServices _generalServices;

    public ContactInformationController(IContactInformationRepository contactInformationRepository,
        GeneralServices generalServices)
    {
        _repository = contactInformationRepository;
        _generalServices = generalServices;
    }
    

    [HttpPut("UpdateContactInformation")]
    public async Task<IActionResult> UpdateContactInformation([FromBody] ContactInformationDto dto)
    {
        var contactInfo = await _repository.GetByIdFirstOrDefaultAsync();

        if (contactInfo == null)
        {
            contactInfo = new ContactInformation
            {
                Phone = dto.Phone,
                Number = dto.Number,
                Email = dto.Email,
                Address = dto.Address,
                PostCode = dto.PostCode,
                Location = dto.Location,
            };

            await _repository.AddAsync(contactInfo);
        }
        else
        {
            contactInfo.Phone = dto.Phone;
            contactInfo.Number = dto.Number;
            contactInfo.Email = dto.Email;
            contactInfo.Address = dto.Address;
            contactInfo.PostCode = dto.PostCode;
            contactInfo.Location = dto.Location;
        }

        await _generalServices.SaveAsync();
        return Ok(dto);
    }
}