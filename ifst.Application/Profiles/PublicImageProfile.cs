using AutoMapper;
using ifst.API.ifst.Application.DTOs.GeneralDto.Image;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class PublicImageProfile : Profile
{
    public PublicImageProfile()
    {
        CreateMap<CreatePublicImageDto, PublicImage>();
        CreateMap<PublicImage, GetPublicImageDto>();
        CreateMap<PublicImage, GetPublicImageDetailDto>();
        CreateMap<UpdatePublicImageDto, PublicImage>();
    }
}