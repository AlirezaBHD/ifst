namespace ifst.API.ifst.Application.DTOs.StudentDto;

public class StudentListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? Field { get; set; }
    public string NationalCode { get; set; }
    public string? StudentId { get; set; }
}