using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;
[DisplayName("خییر")]
public class Pioneers
{
    public int Id { get; set; }
    [MaxLength(50)] public string Name { get; set; }
    public string CityOfBirth { get; set; }
    public string ImagePath { get; set; }
    public string ProjectsDescription { get; set; }
}