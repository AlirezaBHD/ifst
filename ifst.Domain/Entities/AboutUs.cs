using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("پروژه")]

public class AboutUs
{
    
    public int Id { get; set; }
    [Required] public string Introduction { get; set; }
    [Required] public string Statutes { get; set; }
    [Required] public string ActivityLicense { get; set; }
    [Required] public string FoundingBoard { get; set; }
    [Required] public string BoardOfTrustees { get; set; }
    [Required] public string BoardOfDirectors { get; set; }
    [Required] public string CEO { get; set; }
    [Required] public string CommitteesAndWorkingGroups { get; set; }
    [Required] public string Archive { get; set; }
    [Required] public string Reports { get; set; }
}