﻿using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IAlbumService
{
    Task<AlbumDto> CreateAlbumAsync(CreateAlbumDto createAlbumDto);

    Task<AlbumDto> GetAlbumByIdAsync(int id);

    Task DeleteAlbumByIdAsync(int id);

    Task UpdateAlbum(EditAlbumDto albumDto);
    Task<PaginatedResult<ListedAlbumsDto>> GetAlbumsAsync(FilterAndSortPaginatedOptions options);

}