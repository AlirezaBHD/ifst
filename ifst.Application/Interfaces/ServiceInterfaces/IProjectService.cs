﻿using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Extensions;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IProjectService
{
    Task<ProjectDto> AddProjectAsync(GetObjectByIdDto institute, CreateProjectDto projectDto);

    // Task<IEnumerable<Newsletter>> GetProjectsAsync(FilterAndSortPaginatedOptions options);
    //
    Task<ProjectDetailDto> GetProject (GetObjectByIdDto projectDto);
    //
    // Task<Newsletter> UpdateProject(int id, PatchNewsletterDto newsletterDto);
    //
    // Task DeleteProject(GetObjectByIdDto newsletter);
}