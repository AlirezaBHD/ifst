using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Domain.ValueObjects;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IInstituteRepository _instituteRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices<Project> _generalServices;
    private readonly FileService _fileService;

    public ProjectService(IProjectRepository projectRepository, IGeneralServices<Project> generalServices,
        FileService fileService, IMapper mapper, IInstituteRepository instituteRepository)
    {
        _projectRepository = projectRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
        _instituteRepository = instituteRepository;
    }

    public async Task<ProjectDto> AddProjectAsync(GetObjectByIdDto institute, CreateProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var imagePath = await _fileService.SaveFileAsync(projectDto.ImageFile, "Project");
        project.ImagePath = imagePath;
        await _projectRepository.AddAsync(project);
        var instituteObj = await _instituteRepository.GetByIdAsync(institute.Id);
        instituteObj.Projects.Add(project);
        await _projectRepository.SaveAsync();
        var projectDtoObj = _mapper.Map<ProjectDto>(project);
        return projectDtoObj;
    }

    public async Task<ProjectDetailDto> GetProject(GetObjectByIdDto projectDto)
    {
        var project = await _projectRepository.GetByIdAsyncLimited<ProjectDetailDto>(projectDto.Id,
            condition: p => p.Status == ProjectStatus.Approved, includes: project => project.Institute);
        return project;
    }

    public async Task DeleteProject(GetObjectByIdDto projectDto)
    {
        var project = await _projectRepository.GetByIdAsync(projectDto.Id);
        _projectRepository.Remove(project);
        await _projectRepository.SaveAsync();
    }

    public async Task UpdateProject(GetObjectByIdDto projectDto, InstituteUpdateProjectDto updateProjectDto)
    {
        var projectDtoObj = await _projectRepository.GetByIdAsync(projectDto.Id);
        var files = new Dictionary<string, IFormFile>
        {
            { nameof(projectDtoObj.ImagePath), updateProjectDto.ImageFile }
        };

        await _generalServices.UpdateEntityAsync(projectDtoObj, updateProjectDto, files);
    }


    public async Task<IEnumerable<ProjectsName>> GetProjectsAsync()
    {
        // var projectsDto = _mapper.Map<IEnumerable<ProjectsName>>(projects);
        // var projectsDto = projects.Select(p => _mapper.Map<ProjectsName>(p));


        // var projects = await _projectRepository.GetAllAsync(p => _mapper.Map<ProjectsName>(p));
        // return projects;
        throw new NotImplementedException();
    }
}