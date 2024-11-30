using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface INoteService
{
    Task<NoteDto> AddNote(AddNoteDto noteDto);

    Task<NoteCompleteDto> GetNote(GetObjectByIdDto noteDto);
    Task DeleteNote(GetObjectByIdDto noteDto);

    Task<PaginatedResult<listedNoteDto>> GetNewslettersAsync(FilterAndSortPaginatedOptions options);

}