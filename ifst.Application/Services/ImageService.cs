using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class ImageService : IImageService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IMapper _mapper;
    private readonly FileService _fileService;

    private readonly IGeneralServices _generalServices;

    public ImageService(IAlbumRepository albumRepository, IImageRepository imageRepository, IMapper mapper,
        FileService fileService, IGeneralServices generalServices)
    {
        _albumRepository = albumRepository;
        _imageRepository = imageRepository;
        _mapper = mapper;
        _fileService = fileService;
        _generalServices = generalServices;
    }

    public async Task<ImageDto> AddImageAsync(AddImageDto addImageDto, GetAlbumDto getAlbumDto)
    {
        var album = await _albumRepository.GetByIdAsync(getAlbumDto.Id);


        var path = await _fileService.SaveFileAsync(addImageDto.File, "Albums");


        var image = _mapper.Map<Image>(addImageDto);
        image.Path = path;
        image.AlbumId = album.Id;


        await _imageRepository.AddAsync(image);
        album.Images.Add(image);
        await _generalServices.SaveAsync();

        var imageDto = _mapper.Map<ImageDto>(image);
        return imageDto;
    }

    public async Task<ImageDto> GetImageByIdAsync(GetImageDto getImageDto)
    {
        var image = await _imageRepository.GetByIdAsync(getImageDto.Id);
        var imageDtoObj = _mapper.Map<ImageDto>(image);
        return imageDtoObj;
    }
}