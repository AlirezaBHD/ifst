using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.DTOs.NewsDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<CreateNewsDto, News>();
        CreateMap<News, NewsDto>();
        CreateMap<News, NewsDetailDto>();
        CreateMap<UpdateNewsDto, News>();
        CreateMap<News, ListedNewsDto>();
    }
}