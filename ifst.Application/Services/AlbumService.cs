﻿using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;

    public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IGeneralServices generalServices)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
        _generalServices = generalServices;
    }

    public async Task<AlbumDto> CreateAlbumAsync(CreateAlbumDto createAlbumDto)
    {
        var album = _mapper.Map<Album>(createAlbumDto);

        await _albumRepository.AddAsync(album);

        await _generalServices.SaveAsync();

        return _mapper.Map<AlbumDto>(album);
    }

    public async Task<AlbumDto> GetAlbumByIdAsync(int id)
    {
        var album = await _albumRepository.GetByIdAsync(id);
        var albumDtoObj = _mapper.Map<AlbumDto>(album);
        return albumDtoObj;
    }

    public async Task DeleteAlbumByIdAsync(int id)
    {
        var album = await _albumRepository.GetByIdAsync(id);
        _albumRepository.Remove(album);
        await _generalServices.SaveAsync();
    }
}