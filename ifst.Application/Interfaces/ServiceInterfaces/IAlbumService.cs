using ifst.API.ifst.Application.DTOs;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface  IAlbumService
{
    Task<AlbumDto> CreateAlbumAsync(CreateAlbumDto createAlbumDto);

    Task<AlbumDto> GetAlbumByIdAsync(int id);
    
    Task DeleteAlbumByIdAsync(int id);
}