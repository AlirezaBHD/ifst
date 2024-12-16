using AutoMapper;
using ifst.API.ifst.Application.DTOs.AparatVideoDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class AparatVideoProfile : Profile
{
    public AparatVideoProfile()
    {
        CreateMap<CreateAparatVideoDto, AparatVideo>();

    }
}