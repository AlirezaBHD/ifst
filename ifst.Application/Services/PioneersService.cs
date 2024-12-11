using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class PioneersService : IPioneersService
{
    private readonly IMapper _mapper;
    private readonly FileService _fileService;
    private readonly IGeneralServices<Pioneers> _generalServices;
    private readonly IPioneersRepository _pioneersRepository;

    public PioneersService(IPioneersRepository pioneersRepository, IMapper mapper,
        FileService fileService, IGeneralServices<Pioneers> generalServices)
    {
        _pioneersRepository = pioneersRepository;
        _mapper = mapper;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    public async Task<PioneersDto> AddPioneerAsync(AddPioneersDto pioneerDto)
    {
        var path = await _fileService.SaveFileAsync(pioneerDto.File, "Pioneer");

        var pioneer = _mapper.Map<Pioneers>(pioneerDto);
        pioneer.ImagePath = path;

        await _pioneersRepository.AddAsync(pioneer);
        await _pioneersRepository.SaveAsync();

        var pioneerDtoObj = _mapper.Map<PioneersDto>(pioneer);
        return pioneerDtoObj;
    }

    public async Task<PioneersDto> GetPioneerAsync(GetPioneersDto getPioneerDto)
    {
        var pioneer = await _pioneersRepository.GetByIdAsync(getPioneerDto.Id);
        var pioneerDtoObj = _mapper.Map<PioneersDto>(pioneer);
        return pioneerDtoObj;

    }

    public async Task<PaginatedResult<PioneersDto>> GetAllPioneersAsync(GetAllPioneersDto getPioneersDto)
    {
        // var totalPioneers = await _pioneersRepository.GetAllAsync();
        var totalPioneers = await _pioneersRepository.GetAllAsync();
        var totalCount = totalPioneers.Count();

        var paginatedPioneers = await _pioneersRepository.GetAllPaginated<PioneersDto>(getPioneersDto.Page,getPioneersDto.PageSize);
            
        // var dtoResult = new PaginatedResult<PioneersDto>
        // {
        //         
        //     Items = paginatedPioneers.Items.Select(p => _mapper.Map<PioneersDto>(p)).ToList(),
        //     TotalCount = paginatedPioneers.TotalCount,
        //     PageNumber = paginatedPioneers.PageNumber,
        //     PageSize = paginatedPioneers.PageSize
        // };
        
        
        return paginatedPioneers;

    }

    public async Task RemovePioneerAsync(GetPioneersDto pioneerDto)
    {
        var pioneer =await _pioneersRepository.GetByIdAsync(pioneerDto.Id);
        _pioneersRepository.Remove(pioneer);
        await _pioneersRepository.SaveAsync();
    }

    public async Task<PioneersDto> UpdateNewsletterAsync(int id, UpdatePioneerDto pioneerDto)
    {
        var obj = await _pioneersRepository.GetByIdAsync(id);


        var updatedPioneer = _mapper.Map(pioneerDto, obj);
        if (pioneerDto.File != null)
        {
            var imagePath = await _fileService.SaveFileAsync(pioneerDto.File, "Newsletter");
            updatedPioneer.ImagePath = imagePath;
        }

        var updatedPioneerDto = _mapper.Map<PioneersDto>(updatedPioneer);
        

        _pioneersRepository.Update(updatedPioneer);
        await _pioneersRepository.SaveAsync();
        return updatedPioneerDto;
    }

}