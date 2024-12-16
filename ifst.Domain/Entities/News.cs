using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("خبر")]
public class News
{
    public News()
    {
        Date = DateTime.Now;
    }

    public int Id { get; set; }
    [MaxLength(50)] [Required] public string Title { get; set; }
    public string ImagePath { get; set; }
    [MaxLength(150)] public string? Summery { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; private set; }
}