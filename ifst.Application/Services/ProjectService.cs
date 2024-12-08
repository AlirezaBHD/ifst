using AutoMapper;
using ifst.API.ifst.Application.DTOs;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.FileManagement;

namespace ifst.API.ifst.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IInstituteRepository _instituteRepository;
    private readonly IMapper _mapper;
    private readonly IGeneralServices _generalServices;
    private readonly FileService _fileService;
    public ProjectService(IProjectRepository projectRepository, IGeneralServices generalServices, FileService fileService, IMapper mapper, IInstituteRepository instituteRepository)
    {
        _projectRepository = projectRepository;
        _generalServices = generalServices;
        _fileService = fileService;
        _mapper = mapper;
        _instituteRepository = instituteRepository;
    }

    public async Task  AddProjectAsync(GetObjectByIdDto institute, CreateProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var imagePath = await _fileService.SaveFileAsync(projectDto.ImageFile, "Project");
        project.ImagePath = imagePath;
        await _projectRepository.AddAsync(project);
        var instituteObj =await _instituteRepository.GetByIdAsync(institute.Id);
        instituteObj.Projects.Add(project);
        await _generalServices.SaveAsync();

    }

    public async Task<ProjectDetailDto> GetProject(GetObjectByIdDto projectDto)
    {
        var project = await _projectRepository.GetByIdWithIncludesAsync(projectDto.Id, project => project.Institute);
        var projectObj = _mapper.Map<ProjectDetailDto>(project);
        return projectObj;
    }
}