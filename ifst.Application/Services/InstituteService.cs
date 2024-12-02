using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.Application.Services;

public class InstituteService: IInstituteService
{
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;
    private readonly IInstituteRepository _instituteRepository;
    private readonly FileService _fileService;

    public InstituteService(IMapper mapper, IGeneralServices generalServices,
        IInstituteRepository instituteRepository, FileService fileService)
    {
        _instituteRepository = instituteRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<InstituteDto> AddInstitute(CreateInstituteDto createInstituteDto)
    {
        var imagePath = await _fileService.SaveFileAsync(createInstituteDto.Image, "Institute");
        var institute = _mapper.Map<Institute>(createInstituteDto);
        institute.ImagesPath = imagePath;
        await _instituteRepository.AddAsync(institute);
        await _generalServices.SaveAsync();
        var dto = _mapper.Map<InstituteDto>(institute);
        return dto;
        
    }
}