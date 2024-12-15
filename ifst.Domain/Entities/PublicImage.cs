using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("تصویر")]

public class PublicImage
{
    public int Id { get; set; }
    [Required]
    public string Path  { get; set; }
    public string? Description  { get; set; }
}