using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Application.Services;

public class InstituteService : IInstituteService
{
    #region Injections
    
    private readonly IMapper _mapper;
    private readonly IGeneralServices<Institute> _generalServices;
    private readonly IInstituteRepository _instituteRepository;
    private readonly FileService _fileService;
    private readonly IPatchService<Institute, PatchInstitutesDto> _patchService;
    
    public InstituteService(IMapper mapper, IGeneralServices<Institute> generalServices,
        IInstituteRepository instituteRepository, FileService fileService, IPatchService<Institute, PatchInstitutesDto> patchService)
    {
        _instituteRepository = instituteRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _patchService = patchService;
        _mapper = mapper;
    }

    #endregion
    

    #region Add Institute

    public async Task<InstituteDto> AddInstitute(CreateInstituteDto createInstituteDto)
    {
        var imagePath = await _fileService.SaveFileAsync(createInstituteDto.Image, "Institute");
        var institute = _mapper.Map<Institute>(createInstituteDto);
        institute.ImagesPath = imagePath;
        await _instituteRepository.AddAsync(institute);
        await _instituteRepository.SaveAsync();
        var dto = _mapper.Map<InstituteDto>(institute);
        return dto;
    }

    #endregion
    

    #region Get Institute

    public async Task<InstituteDto> GetInstitute(int id)
    {
        var institute = await _instituteRepository.GetByIdAsyncLimited<InstituteDto>(id, condition:i => i.Confirmed == true, includes:i=>i.Projects);
        return institute;
    }

    #endregion

    #region Update Institute

    public async Task UpdateInstitute(int id ,CreateInstituteDto instituteDto)
    {
        var instutute = await _instituteRepository.GetByIdAsync(id);
        _generalServices.UpdateEntityAsync(instutute, instituteDto );
    }

    #endregion
    
    #region Get All Institutes

    public async Task<PaginatedResult<MainListedInstitutesDto>> GetAllInstitutes(int pageNumber,
        int pageSize)
    {
        
        var institutes = await _instituteRepository.GetAllPaginated<MainListedInstitutesDto>(pageNumber, pageSize);
        return institutes;
    }

    #endregion


    #region Get All Confirmed Institutes

    public async Task<IEnumerable<ListedInstitutesDto>> GetAllConfirmedInstitutes()
    {
        var institutes = await _instituteRepository.FindAsync(e => e.Confirmed == true);
        var institutesDto = _mapper.Map<IEnumerable<Institute>,IEnumerable<ListedInstitutesDto>>(institutes);
        return institutesDto;
    }

    #endregion
    

    #region Patch

    public async Task PatchInstitute(int id,JsonPatchDocument<PatchInstitutesDto> patchDoc )
    {
        //
        // var institute = await _instituteRepository.GetByIdAsync(id);
        // var newInstitute = _mapper.Map<PatchInstitutesDto>(institute);
        // // patchDoc.ApplyTo(newInstitute);
        // patchDoc.ApplyTo(newInstitute, error =>
        // {
        //     throw new Exception($"Patch error: {error.ErrorMessage}");
        // });
        //
        // _mapper.Map(newInstitute, institute);
        await _patchService.PatchAsync(id, patchDoc);
        await _instituteRepository.SaveAsync();
    }

    #endregion

    
    #region Institute Status

    public async Task InstituteStatus(GetObjectByIdDto instituteDto, PatchInstitutesStatusDto institutesStatusDto)
    {
        var institute = await _instituteRepository.GetByIdAsync(instituteDto.Id);
        institute.Confirmed = institutesStatusDto.Confirmed == "true";
        await _instituteRepository.SaveAsync();
    }

    

    #endregion


    #region Get All Institutes And Projects

    public async Task<IEnumerable<InstituteDto>> GetAllInstitutesAndProjects()
    {
        var institutes = await _instituteRepository.GetAllInstitutesAndProjects();
        return institutes;
    }

    #endregion
}