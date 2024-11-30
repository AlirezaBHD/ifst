using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController: ControllerBase
{
    private readonly INoteService _noteService;
    
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    // [HttpGet]

    [HttpPost("AddNote")]
    public async Task<IActionResult> AddNote(AddNoteDto noteDto)
    {
        await _noteService.AddNote(noteDto);
        // return Created()
        return Ok(".یاداشت افزوده شد");
    }
}