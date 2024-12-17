using System.ComponentModel.DataAnnotations;

namespace ifst.API.ifst.Application.DTOs;

public class CreateAboutUsDto
{
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