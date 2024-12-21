namespace ifst.API.ifst.Application.DTOs.UpdateProjectDto;

public class UpdateProjectListDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public int Progress { get; set; }
    public bool Accepted { get; set; }
    public string ProjectTitle { get; set; }
    public int ProjectId { get; set; }
}