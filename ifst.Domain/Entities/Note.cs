using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;
using Microsoft.AspNetCore.Html;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("یاداشت")]
public class Note
{
    public Note()
    {
        Date = DateTime.Now;
    }

    public int Id { get; set; }
    [MaxLength(50)] [Required] public string Title { get; set; }
    [MaxLength(150)] public string? Summery { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; private set; }
}