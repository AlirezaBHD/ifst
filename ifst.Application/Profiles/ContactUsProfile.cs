using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class ContactUsProfile : Profile
{
    public ContactUsProfile()
    {
        CreateMap<ContactUsDto, ContactUs>();
        CreateMap<ContactUs, ContactUsDto>();
    }
}