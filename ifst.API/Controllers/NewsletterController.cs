using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterRepository _newsletterRepository;
    private readonly INewsletterService _newsletterService;
    private readonly FileService _fileService;
    private readonly IGeneralServices _generalServices;

    public NewsletterController(INewsletterService newsletterService, INewsletterRepository newsletterRepository,
        FileService fileService, IGeneralServices generalServices)
    {
        _newsletterService = newsletterService;
        _newsletterRepository = newsletterRepository;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    [HttpGet("GetNewsletter")]
    public async Task<IActionResult> GetNewsletter([FromQuery] GetObjectByIdDto newsletter)
    {
        var newsletterObj = await _newsletterService.GetNewsletter(newsletter);
        return Ok(newsletterObj);
    }


    [HttpPost("AddNewsletter")]
    public async Task<IActionResult> AddNewsletter([FromForm] AddNewsletterDto newsletter)
    {
        var newsletterObj = await _newsletterService.AddNewsletterAsync(newsletter);
        return Ok(newsletterObj);
    }

    [HttpGet("GetFilteredNewsletters")]
    public async Task<IActionResult> GetFilteredNewsletters([FromQuery] FilterAndSortPaginatedOptions options)
    {
        var result = await _newsletterService.GetNewslettersAsync(options);
        return Ok(result);
    }

    [HttpPut("UpdateNewsletter/{newsletterId.Id}")]
    public async Task<IActionResult> UpdateNewsletter([FromRoute] GetObjectByIdDto newsletterId, [FromForm] PatchNewsletterDto newsletterDto)
    {
        var result = await _newsletterService.UpdateNewsletterAsync(newsletterId.Id,newsletterDto );
        return Ok(result);
        return Ok("|");
    }
    
    [HttpDelete("RemoveNewsletter/{newsletterId.Id}")]
    public async Task<IActionResult> RemoveNewsletter([FromRoute] GetObjectByIdDto newsletterId)
    {
        await _newsletterService.DeleteNewsletterAsync(newsletterId);
        return Ok(".خبرنامه حدف شد");
    }
}