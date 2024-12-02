using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class ImageProfile: Profile
{
    public ImageProfile()
    {
        CreateMap<AddImageDto,Image >();
        CreateMap<Image, ImageDto>();
    }
}