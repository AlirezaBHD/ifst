using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;


[DisplayName("آلبوم")]
public class Album
{
    public int Id { get; set; }
    public string Title  { get; set; }
    
    public string? Category { get; set; }
    public ICollection<Image> Images  { get; set; }
}