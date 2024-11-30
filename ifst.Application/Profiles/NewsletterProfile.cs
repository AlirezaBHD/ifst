using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class NewsletterProfile : Profile
{
    public NewsletterProfile()
    {
        CreateMap<Newsletter,NewsletterDto >();
        CreateMap<NewsletterDto,Newsletter >();
        CreateMap<AddNewsletterDto,Newsletter >();
        CreateMap<PatchNewsletterDto,Newsletter >();
    }
    
}