using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class NoteService: INoteService
{
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;
    private readonly INoteRepository _noteRepository;
    private readonly FileService _fileService;


    public NoteService(INoteRepository noteRepository, IGeneralServices generalServices, IMapper mapper, FileService fileService)
    {
        _noteRepository = noteRepository;
        _generalServices = generalServices;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<NoteDto> AddNote(AddNoteDto noteDto)
    {
        var note = _mapper.Map<Note>(noteDto);
        var image = await _fileService.SaveFileAsync(noteDto.Image, "Note");
        note.ImagePath = image;
        await _noteRepository.AddAsync(note);
        await _generalServices.SaveAsync();
        var noteObjDto = _mapper.Map<NoteDto>(note);
        return noteObjDto;
    }

    public async Task<NoteDto> GetNote(GetObjectByIdDto noteDto)
    {
        var note = await _noteRepository.GetByIdAsync(noteDto.Id);
        var noteDtoObj = _mapper.Map<NoteDto>(note);
        return noteDtoObj;
    }

    public async Task DeleteNote(GetObjectByIdDto noteDto)
    {
        var note = await _noteRepository.GetByIdAsync(noteDto.Id);
        _noteRepository.Remove(note);
        await _generalServices.SaveAsync();
    }

}