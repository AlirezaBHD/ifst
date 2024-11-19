using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterRepository _newsletterRepository;
    private readonly FileService _fileService;
    private readonly GeneralServices _generalServices;
    
    public NewsletterController(INewsletterRepository newsletterRepository , FileService fileService, GeneralServices generalServices)
    {
        _newsletterRepository =  newsletterRepository;
        _fileService =  fileService;
        _generalServices =  generalServices;
    }
    [HttpPost("AddNewsletter")]
    public async Task<IActionResult> AddNewsletter(IFormFile file , IFormFile imageFile , [FromForm] string title)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is Required");
        }
        if (imageFile == null || imageFile.Length == 0)
        {
            return BadRequest("Image File is Required");
        }
        
        if (title== null || title.Length == 0)
        {
            return BadRequest("Title is Required");
        }

        var imagePath = await _fileService.SaveFileAsync(imageFile, "Newsletter");
        var filePath = await _fileService.SaveFileAsync(file, "Newsletter");
        
        var newsletterObj = new Newsletter
        {
            Title = title,
            ImagePath = imagePath,
            FilePath = filePath,
        };
        await _newsletterRepository.AddAsync(newsletterObj);
        await _generalServices.SaveAsync();
        
        
        
        return Ok(newsletterObj);
    }
}