using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class InstituteProfile : Profile
{
    public InstituteProfile()
    {
        CreateMap<CreateInstituteDto, Institute>();

        CreateMap<Institute, InstituteDto>();
    }
}
