namespace ifst.API.ifst.Application.DTOs.StudentDto;

public class SearchStudentDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? NationalCode { get; set; }
    public string? StudentId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}