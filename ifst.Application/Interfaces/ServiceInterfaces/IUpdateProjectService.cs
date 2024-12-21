﻿using ifst.API.ifst.Application.DTOs.UpdateProjectDto;

namespace ifst.API.ifst.Application.Interfaces.ServiceInterfaces;

public interface IUpdateProjectService
{
    Task<UpdateProjectDetailDto> UpdateProjectDetail(int id);
    Task<IEnumerable<UpdateProjectListDto>> UpdateProjectList();
    Task UpdateStatus(int id, PatchUpdateProjectDto updateProjectDtoDto);
    Task AddUpdateProject(int id, AddUpdateProject updateProjectDto);
    Task EditUpdateProject(int id, AddUpdateProject updateProjectDto);
    
    Task DeleteUpdateProject(int id);

}