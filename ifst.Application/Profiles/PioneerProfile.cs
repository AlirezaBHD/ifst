using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class PioneerProfile: Profile
{
    public PioneerProfile()
    {
        CreateMap<GetPioneersDto,Pioneers >();
        CreateMap<AddPioneersDto,Pioneers >();
        CreateMap<Pioneers, PioneersDto>();
        CreateMap<UpdatePioneerDto, Pioneers>();
    }
}