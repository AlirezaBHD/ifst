﻿using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class ProjectProfile : Profile
{

    public ProjectProfile()
    {

        CreateMap<CreateProjectDto, Project>();
        CreateMap<Project, ProjectListDto>();
    }
}