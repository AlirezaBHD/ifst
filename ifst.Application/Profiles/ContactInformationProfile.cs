using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class ContactInformationProfile : Profile
{
    public ContactInformationProfile()
    {
        CreateMap<ContactInformationDto, ContactInformation>();
        CreateMap<ContactInformation, ContactInformationDto>();
    }
}