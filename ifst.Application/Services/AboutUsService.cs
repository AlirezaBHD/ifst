using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class AboutUsService : IAboutUsService
{
    private readonly IAboutUsRepository _aboutUsRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<AboutUs> _generalServices;
    private readonly FileService _fileService;

    public AboutUsService(IAboutUsRepository aboutUsRepository, IGeneralServices<AboutUs> generalServices,
        FileService fileService, IMapper mapper)
    {
        _aboutUsRepository = aboutUsRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<AboutUsDto> GetAboutUsAsync()
    {
        var aboutUsObject = await _aboutUsRepository.AboutUsObject();
        if (aboutUsObject == null)
        {
            return new AboutUsDto();
        }
        var aboutUsDto = _mapper.Map<AboutUsDto>(aboutUsObject);
        return aboutUsDto;
    }

    public async Task PutAboutUsAsync(CreateAboutUsDto aboutUsDto)
    {
        var aboutUsObject = await _aboutUsRepository.AboutUsObject();
        
        if (aboutUsObject == null)
        {
            var aboutUsEntity = _mapper.Map<AboutUs>(aboutUsDto);
            await _aboutUsRepository.AddAsync(aboutUsEntity);
        }
        else
        {
            var aboutUsEntity = _mapper.Map(aboutUsDto,aboutUsObject );
            _aboutUsRepository.Update(aboutUsEntity);
        }

        await _aboutUsRepository.SaveAsync();
    }
}