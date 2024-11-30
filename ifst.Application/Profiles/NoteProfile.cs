using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class NoteProfile: Profile
{
    public NoteProfile()
    {
        CreateMap<AddNoteDto, Note>();
        CreateMap<Note, NoteDto>();
        CreateMap<Note, listedNoteDto>();
    }
}