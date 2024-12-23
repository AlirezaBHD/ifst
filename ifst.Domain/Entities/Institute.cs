using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("بنیاد")]
public class Institute
{
    public int Id { get; set; }
    [Required] [MaxLength(75)] public string Name { get; set; }
    [Required] [MaxLength(75)] public string RequesterFullName { get; set; }
    public string? RequesterEmail { get; set; }
    [Required] public string RequesterNationalId { get; set; }
    [DefaultValue(false)] public bool Confirmed { get; set; }
    public string ImagesPath { get; set; }
    public string Description { get; set; }
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}