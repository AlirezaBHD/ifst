using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<Album> _generalServices;

    public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IGeneralServices<Album> generalServices)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
        _generalServices = generalServices;
    }

    public async Task<AlbumDto> CreateAlbumAsync(CreateAlbumDto createAlbumDto)
    {
        var album = _mapper.Map<Album>(createAlbumDto);

        await _albumRepository.AddAsync(album);

        await _albumRepository.SaveAsync();

        return _mapper.Map<AlbumDto>(album);
    }

    public async Task<AlbumDto> GetAlbumByIdAsync(int id)
    {
        var album = await _albumRepository.GetByIdAsyncLimited<AlbumDto>(id);
        return album;
    }

    public async Task DeleteAlbumByIdAsync(int id)
    {
        var album = await _albumRepository.GetByIdAsync(id);
        _albumRepository.Remove(album);
        await _albumRepository.SaveAsync();
    }

    public async Task UpdateAlbum(EditAlbumDto albumDto)
    {
        var album = await _albumRepository.GetByIdAsync(albumDto.Id);
        album.Title = albumDto.Title;
        album.Title = albumDto.Category;
        _albumRepository.Update(album);
        await _albumRepository.SaveAsync();
    }

    public async Task<PaginatedResult<ListedAlbumsDto>> GetAlbumsAsync(FilterAndSortPaginatedOptions options)
    {
        var paginatedResult = await _albumRepository.GetFilteredAndSortedPaginated<ListedAlbumsDto>(options);
        // var mappedItems =_mapper.Map<IEnumerable<Album>, IEnumerable<ListedAlbumsDto>>(paginatedResult.Items);
        
        // var result = new PaginatedResult<ListedAlbumsDto>
        // {
        //     Items = mappedItems,
        //     TotalCount = paginatedResult.TotalCount,
        //     PageNumber = paginatedResult.PageNumber,
        //     PageSize = paginatedResult.PageSize,
        // };
        return paginatedResult;

    }


}