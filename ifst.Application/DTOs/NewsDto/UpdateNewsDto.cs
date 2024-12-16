namespace ifst.API.ifst.Application.DTOs.NewsDto;

public class UpdateNewsDto
{
    public string Title { get; set; }
    
    public IFormFile? Image { get; set; }

    public string? Summery { get; set; }

    public string Body { get; set; }
}