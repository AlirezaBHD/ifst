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

    public ContactInformationController(IContactInformationRepository contactInformationRepository , GeneralServices generalServices)
    {
        _repository = contactInformationRepository;
        _generalServices = generalServices;

    }
    
    [HttpPost("SubmitContactInformation")]
    public async Task<IActionResult> SubmitContactInformation([FromForm] string phone, [FromForm] string number,
        [FromForm] string email, [FromForm] string address, [FromForm] int postCode, [FromForm] string location)
    {
        var contactInformationObj = new ContactInformation
        {
            Phone = phone,
            Number = number,
            Email = email,
            Address = address,
            PostCode = postCode,
            Location = location
        };
        
        await _repository.AddAsync(contactInformationObj);
        await _generalServices.SaveAsync();
        
        // var contactDtoObj = new ContactUsDto
        // {
        //     Id = contactObj.Id,
        //     FullName = contactObj.FullName,
        //     Email = contactObj.Email,
        //     Body = contactObj.Body,
        //     Date = contactObj.Date,
        // };

        // return Ok("success");
        return Ok(contactInformationObj);
    }
}
