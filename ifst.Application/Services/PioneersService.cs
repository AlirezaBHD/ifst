using AutoMapper;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class PioneersService : IPioneersService
{
    private readonly IMapper _mapper;
    private readonly FileService _fileService;
    private readonly IGeneralServices _generalServices;
    private readonly IAlbumRepository _albumRepository;
    private readonly IImageRepository _imageRepository;

    public PioneersService(IAlbumRepository albumRepository, IImageRepository imageRepository, IMapper mapper,
        FileService fileService, IGeneralServices generalServices)
    {
        _albumRepository = albumRepository;
        _imageRepository = imageRepository;
        _mapper = mapper;
        _fileService = fileService;
        _generalServices = generalServices;
    }
    
    
}