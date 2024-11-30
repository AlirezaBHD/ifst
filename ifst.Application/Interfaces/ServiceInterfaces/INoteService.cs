using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface INoteService
{
    Task AddNote(AddNoteDto noteDto);

    Task<NoteDto> GetNote(GetObjectByIdDto noteDto);
}