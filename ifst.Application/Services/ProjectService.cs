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
    private readonly IGeneralServices _generalServices;
    private readonly FileService _fileService;
    private readonly IGenericService<Project> _genrricService;
    public ProjectService(IGenericService<Project> genericService,IProjectRepository projectRepository, IGeneralServices generalServices, FileService fileService, IMapper mapper, IInstituteRepository instituteRepository)
    {
        _genrricService = genericService;
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
        var instituteObj =await _instituteRepository.GetByIdAsync(institute.Id);
        instituteObj.Projects.Add(project);
        await _generalServices.SaveAsync();
        var projectDtoObj = _mapper.Map<ProjectDto>(project);
        return projectDtoObj;

    }

    public async Task<ProjectDetailDto> GetProject(GetObjectByIdDto projectDto)
    {
        var project = await _projectRepository.GetByIdWithIncludesAsync(projectDto.Id, condition:p => p.Status == ProjectStatus.Approved, includes:project => project.Institute);
        var projectObj = _mapper.Map<ProjectDetailDto>(project);
        return projectObj;
    }

    public async Task DeleteProject(GetObjectByIdDto projectDto)
    {
        var project = await _projectRepository.GetByIdAsync(projectDto.Id);
        _projectRepository.Remove(project);
        await _generalServices.SaveAsync();
    }

    public async Task UpdateProject(GetObjectByIdDto projectDto, InstituteUpdateProjectDto updateProjectDto)
    {
        var projectDtoObj = await _projectRepository.GetByIdAsync(projectDto.Id);
        var files = new Dictionary<string, IFormFile>
            {
                { nameof(projectDtoObj.ImagePath),updateProjectDto.ImageFile }
            };

        await _genrricService.UpdateEntityAsync(projectDtoObj,updateProjectDto,files);
    }
}