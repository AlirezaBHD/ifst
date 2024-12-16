namespace ifst.API.ifst.Application.DTOs.NewsDto;

public class NewsDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string ImagePath { get; set; }
    
    public string? Summery { get; set; }
    
    public string Body { get; set; }
    
    public DateTime Date { get; set; }
}