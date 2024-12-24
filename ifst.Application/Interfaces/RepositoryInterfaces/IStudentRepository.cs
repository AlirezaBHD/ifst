using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.StudentDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    Task<PaginatedResult<StudentListDto>> SearchStudentsAsync(SearchStudentDto searchOptions);
}