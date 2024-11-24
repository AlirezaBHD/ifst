using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class AlbumProfile : Profile
{
    public AlbumProfile()
    {
        CreateMap<CreateAlbumDto,Album >();
        CreateMap<GetAlbumDto,Album >();
        CreateMap<Album, AlbumDto>();
    }
}