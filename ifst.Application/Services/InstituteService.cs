﻿using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.Application.Services;

public class InstituteService : IInstituteService
{
    #region Injections
    
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

    #endregion
    

    #region Add Institute

    public async Task<InstituteDto> AddInstitute(CreateInstituteDto createInstituteDto)
    {
        var imagePath = await _fileService.SaveFileAsync(createInstituteDto.Image, "Institute");
        var institute = _mapper.Map<Institute>(createInstituteDto);
        institute.ImagesPath = imagePath;
        // institute.Projects = new List<Project>();
        await _instituteRepository.AddAsync(institute);
        await _generalServices.SaveAsync();
        var dto = _mapper.Map<InstituteDto>(institute);
        return dto;
    }

    #endregion
    

    #region Get Institute

    public async Task<InstituteDto> GetInstitute(int id)
    {
        var institute = await _instituteRepository.GetByIdAsync(id);
        var result = _mapper.Map<InstituteDto>(institute);
        return result;
    }

    #endregion

    #region Get All Institutes

    public async Task<IEnumerable<ListedInstitutesDto>> GetAllInstitutes()
    {
        var institutes = await _instituteRepository.GetAllAsync();
        var institutesDto = _mapper.Map<IEnumerable<Institute>,IEnumerable<ListedInstitutesDto>>(institutes);
        return institutesDto;
    }

    #endregion
    
    #region Deactivate

    public async Task<string> Deactivate(int id)
    {
        var institute = await _instituteRepository.GetByIdAsync(id);
        if (!institute.Confirmed) return ".بنیاد در حال حاضر غیرفعال است";
        institute.Confirmed = false;
        await _generalServices.SaveAsync();
        return ".بنیاد با موفقیت غیرفعال شد";

    }

    #endregion
    

    #region Activate

    public async Task<string> Activate(int id)
    {
        var institute = await _instituteRepository.GetByIdAsync(id);
        if (institute.Confirmed) return ".بنیاد در حال حاضر فعال است";
        institute.Confirmed = true;
        await _generalServices.SaveAsync();
        return ".بنیاد با موفقیت فعال شد";

    }

    #endregion
    
}