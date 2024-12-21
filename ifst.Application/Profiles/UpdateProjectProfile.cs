using AutoMapper;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Profiles;

public class UpdateProjectProfile : Profile
{
    public UpdateProjectProfile()
    {
        CreateMap<UpdateProject, UpdateProjectDetailDto>();
        CreateMap<UpdateProject, UpdateProjectListDto>()
            .ForMember(dest => dest.ProjectTitle, opt =>
                opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.ProjectId, opt =>
                opt.MapFrom(src => src.Project.Id));
        CreateMap<AddUpdateProject, UpdateProject>();

    }
}