using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.Application.DTOs;

public class NewsletterDto
{
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string FilePath { get; set; }
}

public class AddNewsletterDto
{
    public string? Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile? File { get; set; }
}

public class PatchNewsletterDto

{
    public string? Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile? File { get; set; }
}