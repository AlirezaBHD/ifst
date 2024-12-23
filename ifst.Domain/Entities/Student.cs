using System.ComponentModel.DataAnnotations;
using ifst.API.ifst.Domain.Common;

namespace ifst.API.ifst.Domain.Entities;

[DisplayName("دانشجو")]
public class Student
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string LastName { get; set; }
    public string? StudentCardImagePath { get; set; }
    public string? NationalCardImagePath { get; set; }
    public string? Field { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    [Required] public string NationalCode { get; set; }
    public DateOnly? GraduationDate { get; set; }
    public string? YearOfEntry { get; set; }

    public int InstituteId { get; set; }
    public Institute Institute { get; set; }
}