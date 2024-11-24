using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly FileService _fileService;
    private readonly IImageRepository _imageRepository;
    private readonly IAlbumRepository _albumRepository;

    private readonly GeneralServices _generalServices;

    public ImagesController(IMapper mapper, FileService fileService,
        IAlbumRepository albumRepository, IImageRepository imageRepository, GeneralServices generalServices)
    {
        _mapper = mapper;
        _fileService = fileService;
        _imageRepository = imageRepository;
        _albumRepository = albumRepository;

        _generalServices = generalServices;
    }
    
    [HttpPost("AddImage")]
    public async Task<IActionResult> AddImage([FromForm] AddImageDto addImageDto, [FromForm] GetAlbumDto getAlbumDto)
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
        return Ok(imageDto);
    }

    [HttpGet("GetImage")]
    public async Task<IActionResult> GetImage([FromQuery] GetImageDto getImageDto)
    {
        var image = await _imageRepository.GetByIdAsync(getImageDto.Id);
        var imageDtoObj = _mapper.Map<ImageDto>(image);

        return Ok(imageDtoObj);
    }
}