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
        var aboutUsObject = await _aboutUsRepository.AboutUsObject() ?? new AboutUsDto();
        return aboutUsObject;
        var aboutUsObject = await _aboutUsRepository.AboutUsObject();
        if (aboutUsObject == null)
        {
            return new AboutUsDto();
        }
        var aboutUsDto = _mapper.Map<AboutUsDto>(aboutUsObject);
        return aboutUsDto;
    }

    }
}