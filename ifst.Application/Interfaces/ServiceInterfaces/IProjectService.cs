using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IProjectService
{
    Task<ProjectDto> AddProjectAsync(GetObjectByIdDto institute, CreateProjectDto projectDto);

    Task<IEnumerable<ProjectsName>> GetProjectsAsync();
    
    Task<ProjectDetailDto> GetProject (GetObjectByIdDto projectDto);
    
    Task UpdateProject(GetObjectByIdDto projectDto, InstituteUpdateProjectDto newsletterDto);
    
    Task DeleteProject(GetObjectByIdDto projectDto);
}