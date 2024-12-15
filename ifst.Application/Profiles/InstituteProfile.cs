﻿using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Domain.ValueObjects;

namespace ifst.API.ifst.Application.Profiles;

public class InstituteProfile : Profile
{
    public InstituteProfile()
    {
        CreateMap<CreateInstituteDto, Institute>();
        CreateMap<Institute, InstituteDto>()
            .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => 
                src.Projects.Where(p => p.Status == ProjectStatus.Approved)));
        CreateMap<Institute, ListedInstitutesDto>();
        CreateMap<Institute, MainListedInstitutesDto>();
        CreateMap<Institute, PatchInstitutesDto>();
        CreateMap<PatchInstitutesDto, Institute>();
    }
}
