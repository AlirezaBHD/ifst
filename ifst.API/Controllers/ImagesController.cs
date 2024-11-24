using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;
using Microsoft.AspNetCore.Mvc;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;


    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("AddImage")]
    public async Task<IActionResult> AddImage([FromForm] AddImageDto addImageDto, [FromForm] GetAlbumDto getAlbumDto)
    {
        var imageDto = await _imageService.AddImageAsync(addImageDto, getAlbumDto);
        return Ok(imageDto);
    }

    [HttpGet("GetImage")]
    public async Task<IActionResult> GetImage([FromQuery] GetImageDto getImageDto)
    {
        var imageDtoObj = await _imageService.GetImageByIdAsync(getImageDto);
        return Ok(imageDtoObj);
    }
}