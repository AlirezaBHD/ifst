using AutoMapper;
using ifst.API.ifst.Application.DTOs.StudentDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentListDto>();
        CreateMap<Student, StudentDto>();
    }
}