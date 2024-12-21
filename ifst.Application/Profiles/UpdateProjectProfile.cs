using AutoMapper;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class UpdateProjectProfile : Profile
{
    public UpdateProjectProfile()
    {
        CreateMap<UpdateProject, UpdateProjectDetailDto>();
    }
}