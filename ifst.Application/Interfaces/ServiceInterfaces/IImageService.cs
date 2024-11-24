using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IImageService
{
    Task<ImageDto> AddImageAsync(AddImageDto addImageDto, GetAlbumDto getAlbumDto);

    Task<ImageDto> GetImageByIdAsync(GetImageDto getImageDto);
}