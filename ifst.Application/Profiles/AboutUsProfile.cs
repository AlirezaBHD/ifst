using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class AboutUsProfile : Profile
{
    public AboutUsProfile()
    {
        CreateMap<CreateAboutUsDto, AboutUs>();
        CreateMap<AboutUs, AboutUsDto>();
        CreateMap<AboutUsDto, AboutUs>();
    }
}