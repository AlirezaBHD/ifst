using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("بروزرسانی پروژه")]

public class UpdateProject
{
    public UpdateProject()
    {
        Date = DateTime.Now;
    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; private set; }
    public int Progress { get; set; }
    public bool Accepted { get; set; } = false;
    
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}