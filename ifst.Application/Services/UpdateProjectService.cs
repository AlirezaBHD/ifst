using AutoMapper;
using ifst.API.ifst.Application.DTOs.UpdateProjectDto;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class UpdateProjectService : IUpdateProjectService
{
    #region Injection

    private readonly IUpdateProjectRepository _updateProjectRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<UpdateProject> _generalServices;
    private readonly FileService _fileService;

    public UpdateProjectService(IUpdateProjectRepository updateProjectRepository,IProjectRepository projectRepository,
        IGeneralServices<UpdateProject> generalServices,
        FileService fileService, IMapper mapper)
    {
        _updateProjectRepository = updateProjectRepository;
        _projectRepository = projectRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
    }

    #endregion

    #region UpdateProject Detail

    public async Task<UpdateProjectDetailDto> UpdateProjectDetail(int id)
    {
        var projectDetailDto = await _updateProjectRepository.GetByIdAsyncLimited<UpdateProjectDetailDto>(id);
        return projectDetailDto;
    }

    #endregion

    #region UpdateProject List

    public async Task<IEnumerable<UpdateProjectListDto>> UpdateProjectList()
    {
        var projectList = await _updateProjectRepository.GetAllAsyncLimited<UpdateProjectListDto>();
        return projectList;
    }

    #endregion

    #region UpdateStatus

    public async Task UpdateStatus(int id, PatchUpdateProjectDto updateProjectDtoDto)
    {
        var updateProject = await _updateProjectRepository.UpdateProjectObject(id);
        updateProject.Accepted = updateProjectDtoDto.Accepted == "true";
        if (updateProjectDtoDto.Accepted == "true")
        {
            updateProject.Project.Progress = updateProject.Progress;
        }

        await _updateProjectRepository.SaveAsync();
    }
    
    #endregion

    #region Add UpdateProject

    public async Task AddUpdateProject(int id, AddUpdateProjectDto updateProjectDtoDto)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        var updateProject = _mapper.Map<UpdateProject>(updateProjectDtoDto);
        project.Updates.Add(updateProject);
        await _projectRepository.SaveAsync();
    }


    #endregion

    #region Edit UpdateProject

    public async Task EditUpdateProject(int id, AddUpdateProjectDto updateProjectDtoDto)
    {
        var updateProject = await _updateProjectRepository.GetByIdAsync(id);
        await _generalServices.UpdateEntityAsync(updateProject, updateProjectDtoDto);
    }


    #endregion

    #region Delete UpdateProject

    public async Task DeleteUpdateProject(int id)
    {
        var updateProject =await _updateProjectRepository.GetByIdAsync(id);
        _updateProjectRepository.Remove(updateProject);
        await _updateProjectRepository.SaveAsync();
    }


    #endregion
}