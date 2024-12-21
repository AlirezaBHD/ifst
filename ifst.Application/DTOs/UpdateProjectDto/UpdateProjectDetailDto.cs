namespace ifst.API.ifst.Application.DTOs.UpdateProjectDto;

public class UpdateProjectDetailDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
}