using AutoMapper;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class AparatVideoService : IAparatVideoService
{
    #region Injections

    private readonly IMapper _mapper;
    private readonly IGeneralServices<AparatVideo> _generalServices;
    private readonly IAparatVideoRepository _aparatVideoRepository;
    private readonly FileService _fileService;


    public AparatVideoService(IAparatVideoRepository aparatVideoRepository,
        IGeneralServices<AparatVideo> generalServices, IMapper mapper,
        FileService fileService)
    {
        _aparatVideoRepository = aparatVideoRepository;
        _generalServices = generalServices;
        _mapper = mapper;
        _fileService = fileService;
    }

    #endregion

    #region Create AparatVideo Service

    public async Task<AparatVideoDto> CreateAparatVideoAsync(CreateAparatVideoDto aparatVideo)
    {
        var aparatVideoEntity = _mapper.Map<AparatVideo>(aparatVideo);
        await _aparatVideoRepository.AddAsync(aparatVideoEntity);
        await _aparatVideoRepository.SaveAsync();
        var aparatVideoDto = _mapper.Map<AparatVideoDto>(aparatVideoEntity);
        return aparatVideoDto;
    }

    #endregion
    
    #region Get AparatVideo Service

    public async Task<AparatVideoDto> GetAparatVideoAsync(int id)
    {
        var obj = await _generalServices.GetObjectById<AparatVideoDto>(id);
        return obj;
    }

    #endregion

    #region Delete AparatVideo

    public async Task DeleteAparatVideoAsync(int id)
    {
        var obj = await _aparatVideoRepository.GetByIdAsync(id);
        _aparatVideoRepository.Remove(obj);
        await _aparatVideoRepository.SaveAsync();
    }

    #endregion
}