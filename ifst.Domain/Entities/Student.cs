using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("دانشجو")]
public class Student
{
    public int Id { get; set; }
    [MaxLength(50)][Required] public required string Name { get; set; }
    [MaxLength(50)][Required] public required string LastName { get; set; }
    public string? StudentCardImagePath { get; set; }
    public string? NationalCardImagePath { get; set; }
    [MaxLength(50)]public string? LastUniversity { get; set; }
    [MaxLength(50)]public string? Field { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    [MaxLength(50)][Required] public required string NationalCode { get; set; }
    [MaxLength(50)]public string? StudentId { get; set; }
    public DateOnly? GraduationDate { get; set; }
    [MaxLength(10)]public string? YearOfEntry { get; set; }

    public int InstituteId { get; set; }
    public Institute Institute { get; set; }
}