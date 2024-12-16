namespace ifst.API.ifst.Application.DTOs.NewsDto;

public class ListedNewsDto
{
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string ImagePath { get; set; }
    
    public string? Summery { get; set; }
}