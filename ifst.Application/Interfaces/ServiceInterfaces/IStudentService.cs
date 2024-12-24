using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.StudentDto;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IStudentService
{
    Task<PaginatedResult<StudentListDto>> GetSearchedStudent(SearchStudentDto searchOptions);

    Task<StudentDto> GetStudentById(int id);
}