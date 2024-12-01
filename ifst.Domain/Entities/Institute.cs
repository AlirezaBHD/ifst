using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JsonPatchSample.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("آلبوم")]
public class Institute
{
    public int Id { get; set; }
    [Required] [MaxLength(75)] public string Name { get; set; }
    [Required] [MaxLength(75)] public string RequesterFullName { get; set; }
    public Email RequesterEmail { get; set; }
    [Required] public NationalCode RequesterNationalId { get; set; }
    [DefaultValue(false)] public bool Confirmed { get; set; }
    public string ImagesPath { get; set; }
    public string Description { get; set; }
}