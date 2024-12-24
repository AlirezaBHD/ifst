using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.StudentDto;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class StudentService : IStudentService
{
    #region Injection

    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<Student> _generalServices;
    private readonly FileService _fileService;

    public StudentService(IStudentRepository studentRepository, IGeneralServices<Student> generalServices,
        FileService fileService, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }

    #endregion

    #region Get Searched Student

    public async Task<PaginatedResult<StudentListDto>> GetSearchedStudent(SearchStudentDto searchOptions)
    {
        var result = await _studentRepository.SearchStudentsAsync(searchOptions);
        return result;
    }

    #endregion
    
    #region Get Student By Id

    public async Task<StudentDto> GetStudentById(int id)
    {
        var student = await _studentRepository.GetByIdAsyncLimited<StudentDto>(id);
        return student;
    }

    #endregion
    
    
}
