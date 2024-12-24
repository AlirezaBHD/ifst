using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.StudentDto;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    #region Injection

    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    #endregion

    #region Get Searched Student

    [HttpGet("GetSearchedStudent")]
    public async Task<IActionResult> GetSearchedStudent([FromQuery] SearchStudentDto searchOptions)
    {
        var students = await _studentService.GetSearchedStudent(searchOptions);
        return Ok(students);
    }

    #endregion

    #region Get Student By Id

    [HttpGet("GetStudentById/{Id}")]
    public async Task<IActionResult> GetStudentById([FromRoute] GetObjectByIdDto studentId)
    {
        var student = await _studentService.GetStudentById(studentId.Id);
        return Ok(student);
    }

    #endregion
}