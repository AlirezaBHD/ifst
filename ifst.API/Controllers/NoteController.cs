using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
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

    [HttpGet("GetNote/{noteDto.Id}")]
    public async Task<IActionResult> GetNote([FromRoute] GetObjectByIdDto noteDto)
    {
        var noteObjDto = await _noteService.GetNote(noteDto);
        return Ok(noteObjDto);
    }

    [HttpPost("AddNote")]
    public async Task<IActionResult> AddNote([FromForm] AddNoteDto noteDto)
    {
        var noteObjDto = await _noteService.AddNote(noteDto);
        return Created("GetNote", noteObjDto);
    }

    [HttpDelete("DeleteNote/{noteDto.Id}")]
    public async Task<IActionResult> DeleteNote([FromRoute] GetObjectByIdDto noteDto)
    {
        await _noteService.DeleteNote(noteDto);
        return Ok(".یاداشت با موفقیت حذف شد");
    }

    [HttpGet("GetAllNotes")]
    public async Task<IActionResult> GetAllNotes([FromQuery] FilterAndSortPaginatedOptions options)
    {
        var result = await _noteService.GetNotesAsync(options);
        return Ok(result);
    }
}