using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Domain.Entities;


[DisplayName("پروژه")]

public class Project
{
    
    public int Id { get; set; }
    [Required] [MaxLength(75)] public string Name { get; set; }
    public ProjectStatus Status { get; set; }= ProjectStatus.UnCheck;
    [MaxLength(75)] public DateTime StartDate { get; set; }
    [MaxLength(75)] public DateTime GatheringStartDate { get; set; }
    [MaxLength(75)] public string ImagePath { get; set; }
    public string CapitalRequired { get; set; }
    public string City { get; set; }
    public string Place { get; set; }
    public string GatheredSupport { get; set; }
    public string Summery { get; set; }
    public string Description { get; set; }
    
    public int InstituteId { get; set; }
    public Institute Institute { get; set; }
}